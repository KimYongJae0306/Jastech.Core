using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.FrameWork.Device.Grabbers
{
    public abstract class Grabber
    {
        #region 속성

        #endregion

        #region 메서드
        public abstract ConnectionStatus Initialize();

        public abstract bool Release();
        #endregion
    }

    public enum ConnectionStatus
    {
        Success,
        Fail,
        NotFound_Board,
        NotFound_Camera,
    }
}
