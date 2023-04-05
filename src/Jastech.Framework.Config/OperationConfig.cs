using Jastech.Framework.Imaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Config
{
     public class OperationConfig : Config
    {
        #region 속성
        [JsonProperty]
        public bool VirtualMode { get; set; } = false;

        [JsonProperty]
        public string LastModelName { get; set; } = "";

        [JsonProperty]
        public string SystemVersion { get; set; } = "1.0.0";

        [JsonProperty]
        public float DistanceFromPreAlignToLineScanX { get; set; } = 1.0F;  //um

        [JsonProperty]
        public float DistanceFromPreAlignToLineScanY { get; set; } = 1.0F;  //um

        [JsonProperty]
        public float PreAlignToleranceX { get; set; } = 0.0F;  //um

        [JsonProperty]
        public float PreAlignToleranceY { get; set; } = 0.0F;  //um

        [JsonProperty]
        public float PreAlignToleranceTheta { get; set; } = 0.0F;  //degree

        [JsonProperty]
        public bool EnablePreAlign { get; set; } = true;

        [JsonProperty]
        public bool EnableAkkon { get; set; } = true;

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
