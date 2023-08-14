using Cognex.VisionPro;
using Cognex.VisionPro.SearchMax;
using Jastech.Framework.Imaging.VisionAlgorithms.Parameters;
using Jastech.Framework.Util.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters
{
    public class VisionProSearchMaxToolParam : PatternMatching
    {
        [JsonIgnore]
        private CogSearchMaxTool SearchMaxTool { get; set; }

        public CogSearchMaxTool GetTool()
        {
            return SearchMaxTool;
        }

        public ChangedTrainedDelegate ChangedTrained;

        public delegate void ChangedTrainedDelegate(bool isTrained);

        public void CreateTool()
        {
            if (SearchMaxTool == null)
                SearchMaxTool = new CogSearchMaxTool();
        }

        public void SetTrainRegion(CogRectangle roi)
        {
            if (SearchMaxTool == null)
                return;

            CogRectangle rect = new CogRectangle(roi);

            SearchMaxTool.Pattern.Origin.TranslationX = rect.CenterX;
            SearchMaxTool.Pattern.Origin.TranslationY = rect.CenterY;
            SearchMaxTool.Pattern.TrainRegion = rect;
            SearchMaxTool.Pattern.TrainRegion.Changed += TrainRegion_Changed;
        }

        private void TrainRegion_Changed(object sender, CogChangedEventArgs e)
        {
            if (sender is CogSearchMaxTool tool)
            {
                ChangedTrained?.Invoke(tool.Pattern.Trained);
            }
        }

        public ICogRegion GetTrainRegion()
        {
            if (SearchMaxTool == null)
                return null;

            return SearchMaxTool.Pattern.TrainRegion;
        }

        public void SetSearchRegion(CogRectangle roi)
        {
            CogRectangle rect = new CogRectangle(roi);
            rect.Color = CogColorConstants.Green;
            rect.LineStyle = CogGraphicLineStyleConstants.Dot;
            SearchMaxTool.SearchRegion = new CogRectangle(rect);
        }

        public ICogRegion GetSearchRegion()
        {
            return SearchMaxTool.SearchRegion;
        }

        public void SetOrigin(CogTransform2DLinear origin)
        {
            CogTransform2DLinear newOrigin = new CogTransform2DLinear(origin);
            SearchMaxTool.Pattern.Origin = new CogTransform2DLinear(newOrigin);
        }

        public CogTransform2DLinear GetOrigin()
        {
            return SearchMaxTool.Pattern.Origin;
        }

        public bool SetTrainImage(ICogImage image)
        {
            if (SearchMaxTool == null)
                return false;

            try
            {
                var trainRegion = SearchMaxTool.Pattern.TrainRegion as CogRectangle;

                SearchMaxTool.Pattern.TrainImage = image;
            }
            catch (Exception err)
            {
                Logger.Error(ErrorType.Inspection, err.Message);
                return false;
            }
            return true;
        }

        public bool Train()
        {
            if (SearchMaxTool == null)
                return false;

            try
            {
                SearchMaxTool.Pattern.Train();
            }
            catch (Exception err)
            {
                Logger.Error(ErrorType.Inspection, err.Message);
                return false;
            }
            return true;
        }
        public bool Train(ICogImage image)
        {
            if (image == null || SearchMaxTool == null)
                return false;

            try
            {
                var trainRegion = SearchMaxTool.Pattern.TrainRegion as CogRectangle;

                //ICogImage trainImage =  CogImageHelper.CogCopyRegionTool(null, image, trainRegion, false);
                ICogImage trainImage = VisionProImageHelper.CropImage(image, trainRegion);

                SearchMaxTool.Pattern.TrainImage = trainImage;
                SearchMaxTool.Pattern.Train();
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
            if (SearchMaxTool == null)
                return false;

            return SearchMaxTool.Pattern.Trained;
        }

        public ICogImage GetTrainedPatternImage()
        {
            if (SearchMaxTool == null)
                return null;

            if (SearchMaxTool.Pattern.Trained == false)
                return null;

            SearchMaxTool.Pattern.Changed -= TrainRegion_Changed;
            SearchMaxTool.Pattern.Changed += TrainRegion_Changed;

            return SearchMaxTool.Pattern.GetTrainedPatternImage();
        }

        public ICogImage GetInputImage()
        {
            if (SearchMaxTool == null)
                return null;

            return SearchMaxTool.InputImage;
        }

        public void SetInputImage(ICogImage image)
        {
            if (SearchMaxTool == null)
                return;

            SearchMaxTool.InputImage = image;
        }

        public CogSearchMaxResults Run()
        {
            if (SearchMaxTool == null)
                return null;
            SearchMaxTool.Pattern.Train();
            SearchMaxTool.Run();

            return SearchMaxTool.Results;
        }

        public ICogImage GetTrainImage()
        {
            if (SearchMaxTool == null)
                return null;

            return SearchMaxTool.Pattern.TrainImage;
        }

        public CogImage8Grey GetTrainImageMask()
        {
            if (SearchMaxTool == null)
                return null;

            return SearchMaxTool.Pattern.TrainImageMask;
        }

        public ICogRecord CreateCurrentRecord(CogSearchMaxCurrentRecordConstants constants)
        {
            if (SearchMaxTool == null)
                return null;

            SearchMaxTool.CurrentRecordEnable = constants;

            return SearchMaxTool.CreateCurrentRecord();
        }

        public void TrainImageMask(CogImage8Grey image)
        {
            SearchMaxTool.Pattern.TrainImageMask = image;
            //SearchMaxTool.Pattern.Train();
        }

        public VisionProSearchMaxToolParam DeepCopy()
        {
            VisionProSearchMaxToolParam param = new VisionProSearchMaxToolParam();
            param.Name = Name;
            param.Score = Score;
            param.MaxAngle = MaxAngle;

            if (SearchMaxTool != null)
            {
                if (SearchMaxTool.InputImage is CogImage8Grey grey)
                    grey.Dispose();

                if (SearchMaxTool.InputImage is CogImage24PlanarColor color)
                    color.Dispose();

                SearchMaxTool.InputImage = null;

                param.SearchMaxTool = new CogSearchMaxTool(SearchMaxTool);
            }

            return param;
        }

        public void SaveTool(string dirPath)
        {
            if (Directory.Exists(dirPath) == false)
                Directory.CreateDirectory(dirPath);

            string fileName = string.Format(@"{0}.vpp", Name);
            string path = Path.Combine(dirPath, fileName);

            if (SearchMaxTool == null)
            {
                SearchMaxTool = new CogSearchMaxTool();
                SearchMaxTool.RunParams.RunAlgorithm = CogSearchMaxRunAlgorithmConstants.Standard;
                SearchMaxTool.RunParams.AcceptThreshold = 0.1;
                //SearchMaxTool.RunParams.ApproximateNumberToFind = 1;
                //SearchMaxTool.RunParams.ScoreUsingClutter = false;
            }

            VisionProFileHelper.SaveTool<CogSearchMaxTool>(path, SearchMaxTool);
        }

        public void LoadTool(string dirPath)
        {
            string fileName = string.Format("{0}.vpp", Name);
            string path = Path.Combine(dirPath, fileName);

            if (File.Exists(path))
            {
                SearchMaxTool = VisionProFileHelper.LoadTool(path) as CogSearchMaxTool;
            }
            else
            {
                SaveTool(dirPath);
            }
        }

        public void Dispose()
        {
            if (SearchMaxTool != null)
            {
                if (SearchMaxTool.Pattern.TrainImage != null)
                {
                    if (SearchMaxTool.Pattern.TrainImage is CogImage8Grey grey)
                        grey.Dispose();
                    if (SearchMaxTool.Pattern.TrainImage is CogImage24PlanarColor color)
                        color.Dispose();
                }
                SearchMaxTool.Pattern.TrainImage = null;
                SearchMaxTool.Pattern.Dispose();
                SearchMaxTool.Pattern = null;

                if (SearchMaxTool.InputImage != null)
                {
                    if (SearchMaxTool.InputImage is CogImage8Grey grey)
                        grey.Dispose();
                    if (SearchMaxTool.InputImage is CogImage24PlanarColor color)
                        color.Dispose();
                }

                SearchMaxTool.InputImage = null;
                //SearchMaxTool.RunParams.Dispose();
                SearchMaxTool.RunParams = null;
                if (SearchMaxTool.Results != null)
                    SearchMaxTool.Results.Clear();
                SearchMaxTool.Dispose();
            }

            SearchMaxTool = null;
        }
    }
}
