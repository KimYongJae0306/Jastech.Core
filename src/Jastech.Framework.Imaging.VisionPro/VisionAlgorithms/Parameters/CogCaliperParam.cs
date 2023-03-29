using Cognex.VisionPro.Caliper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters
{
    public class CogCaliperParam
    {
        [JsonProperty]
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public CogCaliperTool CaliperTool { get; set; } = new CogCaliperTool();

        public CogCaliperParam DeepCopy()
        {
            CogCaliperParam param = new CogCaliperParam();
            param.Name = Name;
            param.CaliperTool = new CogCaliperTool(CaliperTool);

            return param;
        }

        public void SaveTool(string dirPath)
        {
            if (Directory.Exists(dirPath) == false)
                Directory.CreateDirectory(dirPath);

            string fileName = string.Format(@"{0}.vpp", Name);
            string path = Path.Combine(dirPath, fileName);

            CogFileHelper.SaveTool<CogCaliperTool>(path, CaliperTool);
        }

        public void LoadTool(string dirPath)
        {
            string fileName = string.Format("{0}.vpp", Name);
            string path = Path.Combine(dirPath, fileName);

            if (File.Exists(path))
                CaliperTool = CogFileHelper.LoadTool(path) as CogCaliperTool;
            else
                SaveTool(dirPath);
        }

        public void Dispose()
        {
            CaliperTool.Dispose();
        }
    }
}
