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
        public VirtualLightCtrl(string name, int numChannel)
            : base(name, numChannel)
        {
        }
        #endregion

        #region 메서드
        public override bool TurnOff()
        {
            return true;
        }

        public override bool TurnOff(int channel, int level)
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
