using Jastech.Framework.Device.Motions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.LAFCtrl
{
    public class VirtualLAFCtrl : LAFCtrl
    {
        public VirtualLAFCtrl(string name) : base(name)
        {
        }

        public override bool Initialize()
        {
            return true;
        }

        public override bool Release()
        {
            return true;
        }

        public override bool IsConnected()
        {
            return true;
        }

        public override void SetMotionRelativeMove(AxisMovingParam.Direction direction, double value)
        {
            
        }
    }
}
