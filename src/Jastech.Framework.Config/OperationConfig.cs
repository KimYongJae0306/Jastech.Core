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
        public int DataStoringDuration { get; set; } = 30; //days

        [JsonProperty]
        public int DataStoringCapacity { get; set; } = 80; //percent

        [JsonProperty]
        public bool SaveImageOK { get; set; } = true;

        [JsonProperty]
        public bool SaveImageNG { get; set; } = true;

        [JsonProperty]
        public ImageExtension ExtensionOKImage { get; set; } = ImageExtension.Jpg;

        [JsonProperty]
        public ImageExtension ExtensionNGImage { get; set; } = ImageExtension.Bmp;
        #endregion

        #region 메서드
        public string GetExtensionOKImage()
        {
            if (ExtensionOKImage == ImageExtension.Bmp)
                return ".bmp";
            else if (ExtensionOKImage == ImageExtension.Jpg)
                return ".jpg";
            else
                return ".bmp";
        }

        public string GetExtensionNGImage()
        {
            if (ExtensionNGImage == ImageExtension.Bmp)
                return ".bmp";
            else if (ExtensionNGImage == ImageExtension.Jpg)
                return ".jpg";
            else
                return ".bmp";
        }
        #endregion
    }
}
