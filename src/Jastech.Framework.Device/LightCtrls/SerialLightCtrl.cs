//using Jastech.Framework.Comm;
//using Jastech.Framework.Comm.Protocol;
//using Jastech.Framework.Util.Helper;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.IO.Ports;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Jastech.Framework.Device.LightCtrls
//{
//    public class SerialLightCtrl : LightCtrl
//    {
//        #region 생성자
//        public SerialLightCtrl(string name, int numChannel)
//            : base(name, numChannel)
//        {
//            ResponseReceived = true;
//        }
//        #endregion


//        #region 속성
//        public SerialPortInfo SerialPortProp { get; set; } = new SerialPortInfo();

//        protected SerialPortComm LightSerialPort { get; private set; }

//        protected ManualResetEvent ResponseReceivedEvent { get; set; } = new ManualResetEvent(false);
//        #endregion


//        #region 메서드
//        public override bool Initialize()
//        {
//            base.Initialize();

//            try
//            {
//                LightSerialPort = new SerialPortComm();
//                LightSerialPort.Initialize(SerialPortProp, GetProtocol());
//                LightSerialPort.Open();
//                LightSerialPort.DataReceived += LightSerialPort_DataReceived;

//                return true;
//            }
//            catch (Exception ex)
//            {
//                LogHelper.Error(ErrorType.LightCtrl, String.Format("Can't open serial port. {0}", ex.Message));
//                LightSerialPort = null;
//            }
//            return false;
//        }

//        protected virtual IProtocol GetProtocol()
//        {
//            StxEtxProtocol protocol = new StxEtxProtocol();
//            protocol.StartChar = StringHelper.StringToByte("");
//            protocol.EndChar = StringHelper.StringToByte("\n\r");
//            return protocol;
//        }

//        private void LightSerialPort_DataReceived(ReceivedPacket receivedPacket)
//        {
//            ResponseReceivedEvent.Set();
//        }

//        public override bool Release()
//        {
//            base.Release();
//            LightSerialPort.Close();
//            return true;
//        }

//        public override bool TurnOff()
//        {
//            LightValue lightValue = LastLightValue.DeepCopy();
//            lightValue.SetZero();
//            return TurnOn(lightValue);
//        }

//        //public override bool TurnOn(LightValue lightValue)
//        //{
//        //    //Logger.Debug(LoggerType.LightCtrl, String.Format("Turn on light : {0}", lightValue.KeyValue));
//        //    ResponseReceived = false;
//        //    for (int channel = StartLightChannel; channel < EndLightChannel; channel++)
//        //    {
//        //        TurnOn(channel, lightValue.Get(channel));
//        //    }
//        //    Thread.Sleep(LightStableTimeMs);
//        //    return ResponseReceived;
//        //}

//        public override bool TurnOn(int channel, int level)
//        {
//            Logger.Debug(LoggerType.LightCtrl, String.Format("Turn on light : {0}", channel));
//            ResponseReceivedEvent.Reset();
//            SendLightPacket(channel - StartLightChannel, level);
//            bool responseReceived = false;
//            if (ResponseRequired == true)
//            {
//                responseReceived = ResponseReceivedEvent.WaitOne(PacketResponseTimeMs);
//            }
//            else
//            {
//                Thread.Sleep(PacketResponseTimeMs);
//                responseReceived = true;
//            }
//            LastLightValue.Set(channel, level);
//            return responseReceived;
//        }

//        //public virtual bool SendLightPacket(int channel, int level)
//        //{
//        //    string packet = String.Format("C{0}{1:000}\r\n", channel + 1, level);
//        //    byte[] dataByte = Encoding.UTF8.GetBytes(packet);
//        //    LightSerialPort.SendPacket(dataByte, 0, 7);
//        //    return true;
//        //}
//        #endregion
//    }
//}
