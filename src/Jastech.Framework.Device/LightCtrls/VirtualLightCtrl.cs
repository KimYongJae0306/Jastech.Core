using Jastech.Framework.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.LightCtrls
{
    public class VirtualLightCtrl : LightCtrl
    {
        #region 생성자
        public VirtualLightCtrl(string name, int totalChannelCount)
            : base(name, totalChannelCount, null)
        {
        }
        #endregion

        #region 메서드
        public override bool Initialize()
        {
            return true;
        }

        public override bool Release()
        {
            return true;
        }

        public override bool TurnOff()
        {
            return true;
        }

        public override bool TurnOff(int channel)
        {
            return true;
        }

        public override bool TurnOn(int channel, int level)
        {
            return true;
        }
        #endregion
    }
}
