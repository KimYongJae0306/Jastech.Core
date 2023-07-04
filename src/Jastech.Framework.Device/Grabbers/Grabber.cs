using Newtonsoft.Json;

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
    }
}
