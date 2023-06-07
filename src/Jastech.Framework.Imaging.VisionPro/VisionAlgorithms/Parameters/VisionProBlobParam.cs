using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Jastech.Framework.Imaging.VisionAlgorithms.Parameters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters
{
    public class VisionProBlobParam
    {
        #region 속성
        [JsonProperty]
        public string Name { get; set; } = "";

        [JsonIgnore]
        private CogBlobTool BlobTool { get; set; } = new CogBlobTool();
        #endregion

        #region 메서드
        public void SetInputImage(ICogImage image)
        {
            BlobTool.InputImage = image;
        }

        public CogBlobResults Run()
        {
            BlobTool.LastRunRecordDiagEnable = CogBlobLastRunRecordDiagConstants.None;
            BlobTool.RunParams.SortEnabled = false;
            BlobTool.RunParams.RegionMode = CogRegionModeConstants.PixelAlignedBoundingBox;
            BlobTool.RunParams.ConnectivityMode = CogBlobConnectivityModeConstants.GreyScale;
            BlobTool.RunParams.ConnectivityCleanup = CogBlobConnectivityCleanupConstants.Fill;
            BlobTool.RunParams.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold;
            BlobTool.RunParams.SegmentationParams.Polarity = CogBlobSegmentationPolarityConstants.DarkBlobs;
            BlobTool.RunParams.ConnectivityMinPixels = 1;
            BlobTool.Run();

           return  BlobTool.Results;
        }

        public VisionProBlobParam DeepCopy()
        {
            VisionProBlobParam param = new VisionProBlobParam();
            param.Name = Name;
            if(BlobTool != null)
                param.BlobTool = new CogBlobTool(BlobTool);

            return param;
        }

        public void SaveTool(string dirPath)
        {
            if (Directory.Exists(dirPath) == false)
                Directory.CreateDirectory(dirPath);

            string fileName = string.Format(@"{0}.vpp", Name);
            string path = Path.Combine(dirPath, fileName);

            if (BlobTool == null)
                BlobTool = new CogBlobTool();

            VisionProFileHelper.SaveTool<CogBlobTool>(path, BlobTool);
        }

        public void LoadTool(string dirPath)
        {
            string fileName = string.Format("{0}.vpp", Name);
            string path = Path.Combine(dirPath, fileName);

            if (File.Exists(path))
            {
                BlobTool = VisionProFileHelper.LoadTool(path) as CogBlobTool;
            }
            else
            {
                SaveTool(dirPath);
            }
        }
        #endregion
    }
}
