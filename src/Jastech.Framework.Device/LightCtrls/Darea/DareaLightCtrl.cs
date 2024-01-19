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
                if (Parser is Darea3StageSerialParser)
                    Protocol = new EmptyProtocol();
                else if (Parser is DareaLightCtrl)
                    Protocol = new EmptyProtocol();
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
            byte[] sendData = null;
            if (Parser is Darea3StageSerialParser)
            {
                throw new NotImplementedException("다래비전 3단 조명타입은 일괄 On이 불가합니다.");
            }
            else if (Parser is DareaSerialParser)
            {
                string message = "AP11";
                sendData = Encoding.UTF8.GetBytes(message);
            }

            return Communition.Send(sendData);
        }

        public override bool TurnOn(int channel)
        {
            byte[] sendData = null;
            if (Parser is Darea3StageSerialParser darea3StageParser)
            {
                darea3StageParser.Command = $"{DareaSendCommand.PWW}";
                darea3StageParser.Channel = channel;    // 채널 자릿수에 맞게 넣어야함 범위 : (0b0000 ~ 0b0111), 2번채널만 On 0b0010
                darea3StageParser.Serialize(out byte[] serializedData);
                sendData = serializedData;
            }
            else if (Parser is DareaSerialParser)
            {
                // ex) 채널 1번을 On 시키고자 할 때 011
                string message = "]";
                message += channel.ToString("D2");
                message += "1";
                sendData = Encoding.UTF8.GetBytes(message);
            }

            return Communition.Send(sendData);
        }

        public override bool TurnOff()
        {

            byte[] sendData = null;
            if (Parser is Darea3StageSerialParser)
            {
                throw new NotImplementedException("다래비전 3단 조명타입은 일괄 Off가 불가합니다.");
            }
            else if (Parser is DareaSerialParser)
            {
                string message = "AP00";
                sendData = Encoding.UTF8.GetBytes(message);
            }

            return Communition.Send(sendData);
        }

        public override bool TurnOff(int channel)
        {
            byte[] sendData = null;
            if (Parser is Darea3StageSerialParser darea3StageParser)
            {
                darea3StageParser.Command = $"{DareaSendCommand.PWW}";
                darea3StageParser.Channel = channel;    // 채널 자릿수에 맞게 넣어야함 범위 : (0b0000 ~ 0b0111), 2번채널만 Off 0b0101
                darea3StageParser.Serialize(out byte[] serializedData);
                sendData = serializedData;
            }
            else if (Parser is DareaSerialParser)
            {
                // ex) 채널 2번을 Off 시키고자 할 때 020
                string message = "]";
                message += channel.ToString("D2");
                message += "0";
                sendData = Encoding.UTF8.GetBytes(message);
            }

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
            if (Protocol.GetType() == typeof(EmptyProtocol))
                return Communition.Send(serializedData);
            else if(Protocol.MakePacket(serializedData, out byte[] sendData))
                    return Communition.Send(sendData);

            return false;
        }
        #endregion
    }
}
