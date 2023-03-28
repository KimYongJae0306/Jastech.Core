using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters
{
    public class CogPatternMatchingParam
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public double Score { get; set; } = 70;

        [JsonProperty]
        public double MaxAngle { get; set; } = 1;

        [JsonIgnore]
        public CogPMAlignTool MatchingTool { get; set; } = new CogPMAlignTool();

        public CogPatternMatchingParam DeepCopy()
        {
            CogPatternMatchingParam param = new CogPatternMatchingParam();
            param.Name = Name;
            param.Score = Score;
            param.MaxAngle = MaxAngle;
            param.MatchingTool = new CogPMAlignTool(MatchingTool);

            return param;
        }

        public void SaveTool(string dirPath)
        {
            if (Directory.Exists(dirPath) == false)
                Directory.CreateDirectory(dirPath);

            string fileName = string.Format(@"{0}.vpp", Name);
            string path = Path.Combine(dirPath, fileName);

            CogFileHelper.SaveTool<CogPMAlignTool>(path, MatchingTool);
        }

        public void LoadTool(string dirPath)
        {
            string fileName = string.Format("{0}.vpp", Name);
            string path = Path.Combine(dirPath, fileName);

            if (File.Exists(path))
            {
                MatchingTool = CogFileHelper.LoadTool(path) as CogPMAlignTool;
            }
            else
            {
                SaveTool(dirPath);
            }
        }

        public void Dispose()
        {
            MatchingTool.Dispose();
        }
    }
}
