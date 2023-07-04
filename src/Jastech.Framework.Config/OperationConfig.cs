using Jastech.Framework.Imaging;
using Newtonsoft.Json;

namespace Jastech.Framework.Config
{
    public class OperationConfig : Config
    {
        #region 속성
        [JsonProperty]
        public static bool UseKeyboard { get; set; } = false;

        [JsonProperty]
        public bool VirtualMode { get; set; } = true;
   
        [JsonProperty]
        public string LastModelName { get; set; } = "";

        [JsonProperty]
        public string SystemVersion { get; set; } = "1.0.0";

        [JsonProperty]
        public int DataStoringDuration { get; set; } = 30; //days

        [JsonProperty]
        public int DataStiringCapcity { get; set; } = 80; //percent

        [JsonProperty]
        public bool SaveImageOK { get; set; } = true;

        [JsonProperty]
        public bool SaveImageNG { get; set; } = true;

        [JsonProperty]
        public ImageExtension ExtensionOKImage { get; set; } = ImageExtension.Bmp;

        [JsonProperty]
        public ImageExtension ExtensionNGImage { get; set; } = ImageExtension.Bmp;

        #endregion
    }
}
