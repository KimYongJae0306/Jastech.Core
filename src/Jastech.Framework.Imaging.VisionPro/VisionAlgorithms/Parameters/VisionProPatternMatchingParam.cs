using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;
using Jastech.Framework.Imaging.VisionAlgorithms.Parameters;
using Jastech.Framework.Util.Helper;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters
{
    public class VisionProPatternMatchingParam : PatternMatching
    {
        #region 속성
        [JsonIgnore]
        private CogPMAlignTool PMTool { get; set; }
        #endregion

        #region 이벤트
        [JsonIgnore]
        public ChangedTrainedDelegate ChangedTrained;
        #endregion

        #region 델리게이트
        public delegate void ChangedTrainedDelegate(bool isTrained);
        #endregion

        #region 메서드
        public CogPMAlignTool GetTool()
        {
            return PMTool;
        }

        public void SetTrainRegion(CogRectangle roi)
        {
            if (PMTool == null)
                return;

            CogRectangle rect = new CogRectangle(roi);

            PMTool.Pattern.Origin.TranslationX = rect.CenterX;
            PMTool.Pattern.Origin.TranslationY = rect.CenterY;
            PMTool.Pattern.TrainRegion = rect;
            PMTool.Pattern.TrainRegion.Changed += TrainRegion_Changed;
        }

        private void TrainRegion_Changed(object sender, CogChangedEventArgs e)
        {
            if (sender is CogPMAlignPattern tool)
            {
                ChangedTrained?.Invoke(tool.Trained);
            }
        }

        public ICogRegion GetTrainRegion()
        {
            if (PMTool == null)
                return null;

            return PMTool.Pattern.TrainRegion;
        }

        public void SetSearchRegion(CogRectangle roi)
        {
            CogRectangle rect = new CogRectangle(roi);
            rect.Color = CogColorConstants.Green;
            rect.LineStyle = CogGraphicLineStyleConstants.Dot;
            PMTool.SearchRegion = new CogRectangle(rect);
        }

        public ICogRegion GetSearchRegion()
        {
            return PMTool.SearchRegion;
        }

        public void SetOrigin(CogTransform2DLinear origin)
        {
            PMTool.Pattern.Origin = origin;
        }

        public CogTransform2DLinear GetOrigin()
        {
            return PMTool.Pattern.Origin;
        }

        public bool Train(ICogImage image)
        {
            if (image == null || PMTool == null)
                return false;

            try
            {
                var trainRegion = PMTool.Pattern.TrainRegion as CogRectangle;

                //ICogImage trainImage =  CogImageHelper.CogCopyRegionTool(null, image, trainRegion, false);
                ICogImage trainImage = VisionProImageHelper.CropImage(image, trainRegion);

                PMTool.Pattern.TrainImage = trainImage;
                PMTool.Pattern.Train();
            }
            catch (Exception err)
            {
                Logger.Error(ErrorType.Inspection, err.Message);
                return false;
            }
            return true;
        }

        public bool IsTrained()
        {
            if (PMTool == null)
                return false;

            return PMTool.Pattern.Trained;
        }

        public ICogImage GetTrainedPatternImage()
        {
            if (PMTool == null)
                return null;

            if (PMTool.Pattern.Trained == false)
                return null;

            PMTool.Pattern.Changed -= TrainRegion_Changed;
            PMTool.Pattern.Changed += TrainRegion_Changed;

            return PMTool.Pattern.GetTrainedPatternImage();
        }

        public ICogImage GetInputImage()
        {
            if (PMTool == null)
                return null;

            return PMTool.InputImage;
        }

        public void SetInputImage(ICogImage image)
        {
            if (PMTool == null)
                return;

            PMTool.InputImage = image;
        }

        public CogPMAlignResults Run()
        {
            if (PMTool == null)
                return null;

            PMTool.Run();

            return PMTool.Results;
        }

        public ICogImage GetTrainImage()
        {
            if (PMTool == null)
                return null;

            return PMTool.Pattern.TrainImage;
        }

        public CogImage8Grey GetTrainImageMask()
        {
            if (PMTool == null)
                return null;

            return PMTool.Pattern.TrainImageMask;
        }

        public ICogRecord CreateCurrentRecord(CogPMAlignCurrentRecordConstants constants)
        {
            if (PMTool == null)
                return null;

            PMTool.CurrentRecordEnable = constants;

            return PMTool.CreateCurrentRecord();
        }

        public void TrainImageMask(CogImage8Grey image)
        {
            PMTool.Pattern.TrainImageMask = image;
            //PMTool.Pattern.Train();
        }

        public VisionProPatternMatchingParam DeepCopy()
        {
            VisionProPatternMatchingParam param = new VisionProPatternMatchingParam();
            param.Name = Name;
            param.Score = Score;
            param.MaxAngle = MaxAngle;

            if (PMTool != null)
            {
                if (PMTool.InputImage is CogImage8Grey grey)
                    grey.Dispose();

                if (PMTool.InputImage is CogImage24PlanarColor color)
                    color.Dispose();

                PMTool.InputImage = null;

                param.PMTool = new CogPMAlignTool(PMTool);
            }

            return param;
        }

        public void SaveTool(string dirPath)
        {
            if (Directory.Exists(dirPath) == false)
                Directory.CreateDirectory(dirPath);

            string fileName = string.Format(@"{0}.vpp", Name);
            string path = Path.Combine(dirPath, fileName);

            if (PMTool == null)
            {
                PMTool = new CogPMAlignTool();
                PMTool.RunParams.RunAlgorithm = CogPMAlignRunAlgorithmConstants.PatQuick;
                PMTool.RunParams.AcceptThreshold = 0.1;
                PMTool.RunParams.ApproximateNumberToFind = 1;
                PMTool.RunParams.ScoreUsingClutter = false;
            }

            VisionProFileHelper.SaveTool<CogPMAlignTool>(path, PMTool);
        }

        public void LoadTool(string dirPath)
        {
            string fileName = string.Format("{0}.vpp", Name);
            string path = Path.Combine(dirPath, fileName);

            if (File.Exists(path))
            {
                PMTool = VisionProFileHelper.LoadTool(path) as CogPMAlignTool;
                //PMTool.Pattern.Origin.
            }
            else
            {
                SaveTool(dirPath);
            }
        }

        public void Dispose()
        {
            if (PMTool != null)
            {
                if (PMTool.Pattern.TrainImage != null)
                {
                    if (PMTool.Pattern.TrainImage is CogImage8Grey grey)
                        grey.Dispose();
                    if (PMTool.Pattern.TrainImage is CogImage24PlanarColor color)
                        color.Dispose();
                }
                PMTool.Pattern.TrainImage = null;
                PMTool.Pattern.Dispose();
                PMTool.Pattern = null;

                if (PMTool.InputImage != null)
                {
                    if (PMTool.InputImage is CogImage8Grey grey)
                        grey.Dispose();
                    if (PMTool.InputImage is CogImage24PlanarColor color)
                        color.Dispose();
                }

                PMTool.InputImage = null;
                PMTool.RunParams.Dispose();
                PMTool.RunParams = null;
                if (PMTool.Results != null)
                    PMTool.Results.Dispose();
                PMTool.Dispose();
            }

            PMTool = null;
        }
        #endregion
    }
}
