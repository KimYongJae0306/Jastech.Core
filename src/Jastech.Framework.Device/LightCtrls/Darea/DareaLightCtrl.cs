using Jastech.Framework.Comm;
using Jastech.Framework.Comm.Protocol;
using Jastech.Framework.Device.LightCtrls.Darea.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.LightCtrls.Darea
{
    public class DareaLightCtrl : LightCtrl
    {
        #region 필드
        #endregion

        #region 속성
        public IDareaParser Parser { get; set; }
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public DareaLightCtrl(string name, int totalChannelCount, IComm comm, IDareaParser dareaParser)
            : base(name, totalChannelCount, comm)
        {
            Parser = dareaParser;
        }
        #endregion

        #region 메서드
        public override bool Initialize()
        {
            if(Communition.GetType() == typeof(SerialPortComm))
            {
                if (Parser.GetType() == typeof(Darea3StageSerialParser))
                {
                }
                else
                    Protocol = new EmptyProtocol();
            }
            Communition.Received += Communition_Received;

            return base.Initialize();// Communition Initalize
        }

        public override bool IsConnected()
        {
            return Communition.IsConnected();
        }

        private void Communition_Received(byte[] data)
        {
           
        }

        public override bool Release()
        {
            Communition.Received -= Communition_Received;
            return base.Release();
        }

        public override bool TurnOn()
        {
            string message = "AP11";

            byte[] sendData = Encoding.UTF8.GetBytes(message);
            Communition.Send(sendData);

            return true;
        }

        public override bool TurnOn(int channel)
        {
            // ex) 채널 1번을 On 시키고자 할 때 011
            string message = "]";
            message += channel.ToString("D2");
            message += "1";

            byte[] sendData = Encoding.UTF8.GetBytes(message);
            return Communition.Send(sendData);
        }

        public override bool TurnOff()
        { 
            
            string message = "AP00";

            byte[] sendData = Encoding.UTF8.GetBytes(message);
            return Communition.Send(sendData);
        }

        public override bool TurnOff(int channel)
        {
            // ex) 채널 2번을 Off 시키고자 할 때 020
            string message = "]";
            message += channel.ToString("D2");
            message += "0";

            byte[] sendData = Encoding.UTF8.GetBytes(message);
            return Communition.Send(sendData);
        }

        public override bool TurnOn(LightValue lightValue)
        {
            bool result = true;
            for (int channel = 0; channel < TotalChannelCount; channel++)
            {
                result |= TurnOn(channel, lightValue.Get(channel));
            }
            return result;
        }

        public override bool TurnOn(int channel, int level)
        {
            Parser.Channel = channel;
            Parser.Value = level;

            Parser.Serialize(out byte[] serializedData);
            if (Protocol.MakePacket(serializedData, out byte[] sendData))
            {
                return Communition.Send(sendData);
            }
            return false;
        }
        #endregion
    }
}
