using Jastech.Framework.Comm.Protocol;
using Jastech.Framework.Util.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace Jastech.Framework.Comm
{
    public class SerialPortComm : IComm
    {
        #region 생성자
        public SerialPortComm()
        {

        }

        public SerialPortComm(string portName, int baudRate, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
        {
            PortName = portName;
            BaudRate = baudRate;
            Parity = parity;
            DataBits = dataBits;
            StopBits = stopBits;
        }
        #endregion

        #region 속성
        [JsonProperty]
        public string PortName { get; set; }

        [JsonProperty]
        public int BaudRate { get; set; }

        [JsonProperty]
        public Parity Parity { get; set; } = Parity.None;

        [JsonProperty]
        public int DataBits { get; set; } = 8;

        [JsonProperty]
        public StopBits StopBits { get; set; } = StopBits.One;

        private SerialPort SerialPort { get; set; }

        private IProtocol Protocol { get; set; }

        private ReceivedPacket ReceivedPacketBuffer { get; } = new ReceivedPacket();
        #endregion

        #region 이벤트
        public event ReceivedEventHandler Received;
        #endregion

        #region 메서드
        public bool Initialize(IProtocol protocol)
        {
            if (SerialPort != null)
                return false;

            if (protocol == null)
                return false;

            Protocol = protocol;
            SerialPort = new SerialPort(PortName, BaudRate, Parity, DataBits, StopBits);
            SerialPort.DataReceived += SerialPort_Protocol_DataReceived;

            return true;
        }

        public bool Release()
        {
            if (SerialPort == null)
                return false;

            Disconnect();
            return true;
        }

        public bool Connect()
        {
            if (SerialPort == null)
                return false;

            try
            {
                SerialPort.Open();
            }
            catch (Exception ex)
            {
                Logger.Error(ErrorType.Comm, $"SerialCommnuication: Connect: {ex.Message}");
                return false;
            }
            return true;
        }

        public bool IsConnected()
        {
            if (SerialPort == null)
                return false;

            return !SerialPort.IsOpen;
        }

        public bool Disconnect()
        {
            if (SerialPort == null)
                return false;

            if (SerialPort.IsOpen)
            {
                SerialPort.Close();
            }
            return true;
        }

        public bool Send(byte[] data)
        {
            if (SerialPort == null)
                return false;
            if (!SerialPort.IsOpen)
                return false;

            if (Protocol == null)
                return false;

            if (!Protocol.MakePacket(data, out byte[] packet))
                return false;

            string gg = Encoding.Default.GetString(packet);
            SerialPort.Write(packet, 0, packet.Length);
            return true;
        }

        public bool Send(string data)
        {
            byte[] dataByte = Encoding.UTF8.GetBytes(data);

            return Send(dataByte);
        }

        private void SerialPort_Protocol_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (e.EventType != SerialData.Chars)
                return;

            var reservedPacketBuffer = new byte[SerialPort.BytesToRead];
            int readCount = SerialPort.Read(reservedPacketBuffer, 0, reservedPacketBuffer.Length);

            if (readCount <= 0)
                return;

            var readPacketBuffer = new byte[readCount];
            Array.Copy(reservedPacketBuffer, readPacketBuffer, readPacketBuffer.Length);
            ReceivedPacketBuffer.Enqueue(readPacketBuffer);
            if (!ReceivedPacketBuffer.Dequeue(Protocol, out List<byte[]> datas))
                return;

            foreach (var data in datas)
            {
                if(data != null)
                    Received?.Invoke(data);
            }
        }
        #endregion
    }
}
