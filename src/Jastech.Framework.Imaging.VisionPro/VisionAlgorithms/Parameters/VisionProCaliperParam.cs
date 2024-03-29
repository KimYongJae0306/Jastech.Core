﻿using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using Newtonsoft.Json;
using System.IO;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters
{
    public class VisionProCaliperParam
    {
        #region 속성
        [JsonIgnore]
        public CogCaliperTool CaliperTool { get; set; } = new CogCaliperTool { LastRunRecordDiagEnable = CogCaliperLastRunRecordDiagConstants.None };
        #endregion

        #region 메서드
        public double GetContrastThreshold()
        {
            if (CaliperTool == null)
                return 0.0;

            return CaliperTool.RunParams.ContrastThreshold;
        }

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

        public VisionProCaliperParam DeepCopy()
        {
            VisionProCaliperParam param = new VisionProCaliperParam();

            if (CaliperTool.InputImage is CogImage8Grey grey)
                grey.Dispose();

            if (CaliperTool.InputImage is CogImage24PlanarColor color)
                color.Dispose();

            CaliperTool.InputImage = null;

            param.CaliperTool = new CogCaliperTool(CaliperTool);

            return param;
        }

        public void SaveTool(string dirPath, string name)
        {
            if (Directory.Exists(dirPath) == false)
                Directory.CreateDirectory(dirPath);

            string fileName = string.Format(@"{0}.vpp", name);
            string path = Path.Combine(dirPath, fileName);

            VisionProFileHelper.SaveTool<CogCaliperTool>(path, CaliperTool);
        }

        public void LoadTool(string dirPath, string name)
        {
            string fileName = string.Format("{0}.vpp", name);
            string path = Path.Combine(dirPath, fileName);

            if (File.Exists(path))
                CaliperTool = VisionProFileHelper.LoadTool(path) as CogCaliperTool;
            else
                SaveTool(dirPath, name);
        }

        public void Dispose()
        {
            if (CaliperTool.InputImage != null)
            {
                if (CaliperTool.InputImage is CogImage8Grey grey)
                    grey.Dispose();
                if (CaliperTool.InputImage is CogImage24PlanarColor color)
                    color.Dispose();
            }
            CaliperTool.InputImage = null;

            CaliperTool.RunParams.Dispose();
            if (CaliperTool.Results != null)
                CaliperTool.Results.Dispose();
            CaliperTool?.Dispose();
            CaliperTool = null;
        }
        #endregion

        public enum CaliperSearchDirection
        {
            InsideToOutside,
            OutsideToInside,
        }
    }
}
