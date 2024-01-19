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
    public class Darea3StageLightCtrl : LightCtrl
    {

        #region 필드
        #endregion

        #region 속성
        public IDareaParser Parser { get; set; }
        #endregion

        #region 생성자
        public Darea3StageLightCtrl(string name, int totalChannelCount, IComm comm, IDareaParser dareaParser) : base(name, totalChannelCount, comm) => Parser = dareaParser;
        #endregion

        #region 메서드
        #endregion

        public override bool Initialize()
        {
            if (Communition.GetType() == typeof(SerialPortComm))
            {
                if (Parser.GetType() == typeof(DareaSerialParser))
                    Protocol = new EmptyProtocol();     // TODO : Protocol 대응되는거 찾기
                else if (Parser.GetType() == typeof(Darea3StageSerialParser))
                    Protocol = new EmptyProtocol();     // TODO : Protocol 대응되는거 찾기
                else
                    Protocol = new EmptyProtocol();
            }
            Communition.Received += Communition_Received;

            return base.Initialize();// Communition Initalize
        }

        private void Communition_Received(byte[] data)
        {
            if(Parser is Darea3StageSerialParser parser)
                parser.Deserialize(data);
        }

        public override bool IsConnected() => base.IsConnected();

        public override bool Release()
        {
            Communition.Received -= Communition_Received;
            return base.Release();
        }

        public override bool TurnOff(int channel) => throw new NotImplementedException();
        public override bool TurnOn(int channel) => throw new NotImplementedException();
        public override bool TurnOn(int channel, int level) => throw new NotImplementedException();


        [Obsolete("제어 대상 채널 구분 모호로 일단 미사용")]
        public override bool TurnOn(LightValue lightValue) => throw new NotImplementedException();
        [Obsolete("전체 On 커맨드 유무 확인, 테스트 후 반영 할 것")]
        public override bool TurnOn() => throw new NotImplementedException();
        [Obsolete("전체 Off 커맨드 유무 확인, 테스트 후 반영 할 것")]
        public override bool TurnOff() => throw new NotImplementedException();
    }
}
