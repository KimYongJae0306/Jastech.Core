using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Grabbers
{
    public enum GrabberType
    {
        Virtual,
        MIL,
    }

    public abstract class Grabber
    {
        #region 속성
        [JsonProperty]
        public GrabberType GrabberType { get; set; }
        #endregion

        #region 메서드

        public abstract void Initialize();

        public abstract void Release();
        #endregion
    }
}
