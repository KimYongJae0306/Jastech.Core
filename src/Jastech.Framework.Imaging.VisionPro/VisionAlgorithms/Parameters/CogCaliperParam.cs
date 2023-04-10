using Cognex.VisionPro;
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

        [JsonProperty]
        public double Score { get; set; } = 70;
        //public Type Direction;

        //public object TargetType;


        [JsonIgnore]
        public CogCaliperTool CaliperTool { get; set; } = new CogCaliperTool();

        public void SetInputImage(ICogImage image)
        {
            if (CaliperTool == null)
                return;

            CaliperTool.InputImage = image;
        }

        public ICogRegion GetRegion()
        {
            if (CaliperTool == null)
                return null;

            return CaliperTool.Region;
        }

        public void SetRegion(CogRectangleAffine roi)
        {
            CogRectangleAffine rect = new CogRectangleAffine(roi);
            rect.Color = CogColorConstants.Green;
            rect.LineStyle = CogGraphicLineStyleConstants.Solid;
            CaliperTool.Region = new CogRectangleAffine(rect);
        }

        public CogCaliperResults Run()
        {
            if (CaliperTool == null)
                return null;

            CaliperTool.Run();

            return CaliperTool.Results;
        }

        public ICogRecord CreateCurrentRecord(CogCaliperCurrentRecordConstants constants)
        {
            if (CaliperTool == null)
                return null;

            CaliperTool.CurrentRecordEnable = constants;
            CaliperTool.LastRunRecordDiagEnable = CogCaliperLastRunRecordDiagConstants.All;
            
            return CaliperTool.CreateCurrentRecord();
        }

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
            CaliperTool?.Dispose();
        }
    }
}
