using Jastech.FrameWork.Comm.Protocol;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.FrameWork.Comm
{
    public class SerialComm
    {
        #region 필드
        private SerialPort _serialPort = new SerialPort();

        private IProtocol protocol;
        #endregion

        #region 속성
        public string PortName { get; set; }

        public SerialPortInfo Info { get; private set; } = new SerialPortInfo();

        public PacketBuffer PacketBuffer { get; } = new PacketBuffer();

        public bool IsOpen
        {
            get
            {
                return _serialPort.IsOpen;
            }
        }
        #endregion

        #region 이벤트
        public event DataReceivedDelegate DataReceived;
        #endregion

        #region 메서드
        public void Initialize(SerialPortInfo serialPortInfo, IProtocol protocol)
        {
            this.protocol = protocol;

            PortName = serialPortInfo.PortName.ToString();
            _serialPort.PortName = PortName;
            _serialPort.BaudRate = serialPortInfo.BaudRate;
            _serialPort.DataBits = serialPortInfo.DataBits;
            _serialPort.StopBits = serialPortInfo.StopBits;
            _serialPort.Parity = serialPortInfo.Parity;
            _serialPort.RtsEnable = serialPortInfo.RtsEnable;
            _serialPort.DtrEnable = serialPortInfo.DtrEnable;
        }

        public bool Open()
        {
            try
            {
                _serialPort.Open();
            }
            catch (Exception ex)
            {
                return false;
            }

            ResetBuffer();
            _serialPort.DataReceived += PortDataReceived;

            return true;
        }

        private void ResetBuffer()
        {
            _serialPort.DiscardInBuffer();
            _serialPort.DiscardOutBuffer();
        }

        public void Close()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.DataReceived -= PortDataReceived;
                _serialPort.Close();
            }
        }

        public void SendPacket(string packetStr)
        {
            SendPacket(new SendPacket(packetStr));
        }

        public void SendPacket(byte[] buffer, int offset, int count)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Write(buffer, offset, count);
            }
        }

        public void SendPacket(SendPacket sendPacket)
        {
            if (sendPacket != null)
            {
                if (_serialPort.IsOpen)
                {
                    byte[] dataByte;
                    if (protocol != null)
                        dataByte = protocol.SendPacket(sendPacket);
                    else
                        dataByte = sendPacket.Data;

                    SendPacket(dataByte, 0, dataByte.Length);
                }
            }
        }

        private void PortDataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int byteToRead = _serialPort.BytesToRead;
            byte[] dataByte = new byte[byteToRead];
            try
            {
                int byteRead = _serialPort.Read(dataByte, 0, byteToRead);
                ParsingPacket(dataByte, byteRead);
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Serial Port Read Error : Name - {0} / Msg - {1} ", PortName, ex.Message));
            }
        }

        private void ParsingPacket(byte[] dataByte, int byteRead)
        {
            ReceivedPacket receivedPacket;
            ParsingResult result;

            PacketBuffer.AppendData(dataByte, byteRead);

            do
            {
                result = protocol.ReceivedPacketParsing(PacketBuffer, out receivedPacket);
                if (result == ParsingResult.Complete)
                {
                    DataReceived?.Invoke(receivedPacket);
                }
                else if (result == ParsingResult.PacketError)
                {
                    PacketBuffer.Clear();
                }

                if (PacketBuffer.Empty == true)
                    break;
            }
            while (result == ParsingResult.Complete);
        }
        #endregion
    }
}
