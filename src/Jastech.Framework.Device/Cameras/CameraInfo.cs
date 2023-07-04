using Jastech.Framework.Imaging;
using Newtonsoft.Json;

namespace Jastech.Framework.Device.Cameras
{
    public class CameraInfo
    {
        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public int ImageWidth { get; protected set; }

        [JsonProperty]
        public int ImageHeight { get; protected set; }

        [JsonProperty]
        public ColorFormat ColorFormat { get; protected set; }

        [JsonProperty]
        public SensorType SensorType { get; protected set; }

        [JsonProperty]
        public TriggerMode TriggerMode { get; set; }
    }

    public class MilCameraInfo : CameraInfo
    {
        [JsonProperty]
        public CameraType CameraType { get; set; }
    }
}
