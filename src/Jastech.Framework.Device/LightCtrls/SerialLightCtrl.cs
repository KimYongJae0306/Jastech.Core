using Jastech.Framework.Comm;
using Jastech.Framework.Comm.Protocol;
using Jastech.Framework.Util.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.LightCtrls
{
    public class SerialLightCtrl : LightCtrl
    {
        #region 생성자
        public SerialLightCtrl(string name, int numChannel)
            : base(name, numChannel)
        {
        }
        #endregion


        #region 속성
        public SerialPortInfo SerialPortProp { get; set; } = new SerialPortInfo();

        protected SerialPortComm LightSerialPort { get; private set; }

        protected ManualResetEvent ResponseReceivedEvent { get; set; } = new ManualResetEvent(false);

        protected bool ResponseRequired { get; set; } = false;

        protected IProtocol Protocol { get; set; } = null;
        #endregion


        #region 메서드
        public override bool Initialize()
        {
            base.Initialize();

            try
            {
                if (Protocol == null)
                    return false;

                LightSerialPort = new SerialPortComm();
                LightSerialPort.Initialize(SerialPortProp, Protocol);
                LightSerialPort.Open();
                LightSerialPort.DataReceived += LightSerialPort_DataReceived;

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ErrorType.LightCtrl, String.Format("Can't open serial port. {0}", ex.Message));
                LightSerialPort = null;
            }
            return false;
        }

        private void LightSerialPort_DataReceived(ReceivedPacket receivedPacket)
        {
            ResponseReceivedEvent.Set();
        }

        public override bool Release()
        {
            base.Release();
            LightSerialPort.Close();
            return true;
        }

        public override bool TurnOff()
        {
            bool success = true;

            for (int i = 0; i < NumChannel; i++)
            {
                success |= TurnOn(i, 0);
            }
            return success;
        }

        public override bool TurnOn(int channel, int level)
        {
            Logger.Write(LogType.Device, String.Format("Turn on light : {0}, {1}", channel, level));

            ResponseReceivedEvent.Reset();

            SendLightPacket(channel, level);
            bool responseReceived = false;
            if (ResponseRequired == true)
            {
                responseReceived = ResponseReceivedEvent.WaitOne(PacketResponseTimeMs);
            }
            else
            {
                Thread.Sleep(PacketResponseTimeMs);
                responseReceived = true;
            }

            return responseReceived;
        }

        public override bool TurnOff(int channel, int level)
        {
            return TurnOn(channel, 0);
        }

        public virtual bool SendLightPacket(int channel, int level)
        {
            string packet = String.Format("C{0}{1:000}\r\n", channel + 1, level);
            byte[] dataByte = Encoding.UTF8.GetBytes(packet);
            LightSerialPort.SendPacket(dataByte, 0, 7);
            return true;
        }
        #endregion
    }

    public class LvsLightCtrl : SerialLightCtrl
    {
        public StxEtxProtocol LvsProtocol { get; private set; } = null;

        public LvsLightCtrl(string name, int numChannel)
            : base(name, numChannel)
        {
           
        }

        public override bool Initialize()
        {
            Protocol = new StxEtxProtocol();

            (Protocol as StxEtxProtocol).StartChar = new byte[1] { 0x01 };
            (Protocol as StxEtxProtocol).EndChar = new byte[1] { 0x04 };

            return base.Initialize();
        }

        public override bool TurnOn(int channel, int level)
        {
            if (SendSelectChannel(channel) == false)
                return false;

            return base.TurnOn(channel, level);
        }

        public override bool SendLightPacket(int channel, int level)
        {
            byte[] dataArray = new byte[4];
            dataArray[0] = 0x00;                    // [OPMode] Write : 0x00, Read : 0x01
            dataArray[1] = 0x01;                    // [DataLength]
            dataArray[2] = 0x20;                    // [Address] Channel Select Register : 0x20 
            dataArray[3] = Convert.ToByte(level);   // Light level

            SendPacket sendPacket = new SendPacket(dataArray);

            LightSerialPort.SendPacket(sendPacket);

            return true;
        }

        private bool SendSelectChannel(int channel)
        {
            byte[] dataArray = new byte[4];
            dataArray[0] = 0x00;                        // [OPMode] Write : 0x00, Read : 0x01
            dataArray[1] = 0x01;                        // [DataLength]
            dataArray[2] = 0x20;                        // [Address] Channel Select Register : 0x20 
            dataArray[3] = Convert.ToByte(channel);     // Channel

            SendPacket sendPacket = new SendPacket(dataArray);

            ResponseReceivedEvent.Reset();
            LightSerialPort.SendPacket(sendPacket);

            bool responseReceived = false;
            if (ResponseRequired == true)
            {
                responseReceived = ResponseReceivedEvent.WaitOne(PacketResponseTimeMs);
            }
            else
            {
                Thread.Sleep(PacketResponseTimeMs);
                responseReceived = true;
            }

            return responseReceived;
        }
    }
}
