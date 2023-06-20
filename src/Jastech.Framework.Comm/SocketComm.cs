using Jastech.Framework.Comm.Protocol;
using Jastech.Framework.Util.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jastech.Framework.Comm
{
    public class SocketComm : IComm
    {
        #region 생성자
        public SocketComm(string ipAddress, int port, SocketCommType socketCommType)
        {
            IpAddress = ipAddress;
            Port = port;
            SocketCommType = socketCommType;
        }
        #endregion

        #region 속성
        [JsonProperty]
        public string IpAddress { get; }

        [JsonProperty]
        public int Port { get; }

        [JsonProperty]
        public SocketCommType SocketCommType { get; set; }

        private Socket Socket { get; set; }

        private IProtocol Protocol { get; set; }

        private static int BufferLength { get; } = 4096;

        private byte[] ReservedPacketBuffer { get; } = new byte[BufferLength];

        private ReceivedPacket ReceivedPacketBuffer { get; } = new ReceivedPacket();

        private Task ReconnectionTask { get; set; }

        private bool ReconnectionRequested { get; set; } = false;
        #endregion

        #region 이벤트
        public event ReceivedEventHandler Received;
        #endregion

        #region 메서드
        public bool Initialize(IProtocol protocol)
        {
            if (Socket != null)
                return false;
            if (protocol == null)
                return false;

            Protocol = protocol;
            ReconnectionTask = Task.Run(() => ReconnectionLoop());
            Connect();
            return true;
        }

        public bool Release()
        {
            if (Socket == null)
                return false;

            if (Socket.Connected)
            {
                Socket.Disconnect(false);
                Socket.Dispose();
            }
            return true;
        }

        public bool Connect()
        {
            if(SocketCommType == SocketCommType.Tcp)
            {
                Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                {
                    NoDelay = true,
                    SendBufferSize = BufferLength,
                    ReceiveBufferSize = BufferLength,
                };
            }
           else if(SocketCommType == SocketCommType.Udp)
            {
                Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                Socket.Bind(new IPEndPoint(IPAddress.Parse("0.0.0.0"), Port));
            }

            bool isSuccessed = BeginConnect();
            return isSuccessed;
        }

        public bool BeginConnect()
        {
            try
            {
                Socket.BeginConnect(IpAddress, Port, new AsyncCallback(Socket_Connected), Socket);

                Thread.Sleep(700);

                if (!Socket.Connected)
                {
                    throw new SocketException();
                }

                return true;
            }
            catch (SocketException ex)
            {
                Logger.Error(ErrorType.Comm, $"Open: Can't connect the server.\n{ex}");
                ReconnectionRequested = true;
                return false;
            }
        }

        private void Socket_Connected(IAsyncResult ar)
        {
            try
            {
                Socket.EndConnect(ar);
                Socket.BeginReceive(ReservedPacketBuffer, 0, ReservedPacketBuffer.Length, SocketFlags.None, new AsyncCallback(Socket_DataReceived), Socket);
            }
            catch (Exception e)
            {
                Logger.Error(ErrorType.Comm, "Can't connect the server" + e.Message);
                ReconnectionRequested = true;
            }
        }

        public bool IsConnected()
        {
            if (Socket == null)
                return false;

            return Socket.Connected;
        }

        public bool Disconnect()
        {
            if (!Socket.Connected)
                return false;

            Socket.Disconnect(true);
            return true;
        }

        public bool Send(byte[] data)
        {
            try
            {
                if (Socket == null || Socket.Connected == false)
                    return false;

                bool ok = data.Length == Socket.Send(data);
                return ok;
            }
            catch (SocketException)
            {
                //Close(false);
                return false;
            }
        }

        public bool Send(string data)
        {
            byte[] dataByte = Encoding.UTF8.GetBytes(data);
            return Send(dataByte);
        }

        private void Socket_DataReceived(IAsyncResult result)
        {
            try
            {
                if (!ReconnectionRequested)
                {
                    if (Socket.Connected)
                    {
                        int readCount = Socket.EndReceive(result);

                        if (readCount != 0)
                        {
                            var readPacketBuffer = new byte[readCount];
                            Array.Copy(ReservedPacketBuffer, 0, readPacketBuffer, 0, readCount);
                            ReceivedPacketBuffer.Enqueue(readPacketBuffer);
                            if (ReceivedPacketBuffer.Dequeue(Protocol, out List<byte[]> datas))
                            {
                                foreach (var data in datas)
                                {
                                    Received?.Invoke(data);
                                }
                            }
                        }
                    }
                }
                this.Receive();
            }
            catch (SocketException ex)
            {
                Logger.Error(ErrorType.Comm, $"Socket_DataReceived:\n{ex}");
                ReconnectionRequested = true;
            }
        }

        public void Receive()
        {
            if (ReconnectionRequested)
                return;

            Socket.BeginReceive(ReservedPacketBuffer, 0, ReservedPacketBuffer.Length, SocketFlags.None, new AsyncCallback(Socket_DataReceived), Socket);
        }

        private void ReconnectionLoop()
        {
            TimeOutTimer timer = new TimeOutTimer();
            while (true)
            {
                if (!ReconnectionRequested)
                {
                    Thread.Sleep(1000);
                    continue;
                }

                Thread.Sleep(1000);
                Logger.Debug(LogType.Comm, "Socket Try Reconnect.");

                while (true)
                {
                    if (IsPingAlive() == false)
                    {
                        Logger.Debug(LogType.Comm, "Ping TimeOut");
                        Thread.Sleep(1000);
                        continue;
                    }

                    try
                    {
                        if (Socket != null)
                        {
                            Socket.Close();
                            Socket.Dispose();
                        }
                        Socket = null;
                    }
                    catch (Exception e)
                    {
                        Logger.Debug(LogType.Comm, "Socket Disconnect Failed. " + e.Message);
                        Socket.Dispose();
                        continue;
                    }

                    timer.Start(1000);

                    try
                    {
                        Connect();

                        while (true)
                        {
                            timer.ThrowIfTimeOut();
                            if (Socket.Connected)
                                break;

                            Thread.Sleep(10);
                        }
                    }
                    catch (TimeoutException)
                    {
                        Logger.Debug(LogType.Comm, "Reconnect TimeOut");
                        continue;
                    }
                    catch (Exception e)
                    {
                        Logger.Debug(LogType.Comm, e.Message);
                        continue;
                    }
                    Thread.Sleep(30);
                    Logger.Debug(LogType.Comm, "Reconnect Success.");
                    ReconnectionRequested = false;
                    break;
                }
            }
        }

        private bool IsPingAlive()
        {
            Ping pingSender = new Ping();
            try
            {
                PingReply reply = pingSender.Send(IpAddress);
                if (reply.Status == IPStatus.Success)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }

    public enum SocketCommType
    {
        Tcp,
        Udp,
    }
}
