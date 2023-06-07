using Cognex.VisionPro;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.PMAlign;
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
    public class VisionProPatternMatchingParam : PatternMatching
    {
        [JsonIgnore]
        private CogPMAlignTool PMTool { get; set; }

        public void SetTrainRegion(CogRectangle roi)
        {
            if (PMTool == null)
                return;

            CogRectangle rect = new CogRectangle(roi);

            PMTool.Pattern.Origin.TranslationX = rect.CenterX;
            PMTool.Pattern.Origin.TranslationY = rect.CenterY;
            PMTool.Pattern.TrainRegion = rect;
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
            PMTool.Pattern.Train();
        }

        public VisionProPatternMatchingParam DeepCopy()
        {
            VisionProPatternMatchingParam param = new VisionProPatternMatchingParam();
            param.Name = Name;
            param.Score = Score;
            param.MaxAngle = MaxAngle;

            if (PMTool.InputImage is CogImage8Grey grey)
                grey.Dispose();

            if (PMTool.InputImage is CogImage24PlanarColor color)
                color.Dispose();

            PMTool.InputImage = null;
            if (PMTool != null)
                param.PMTool = new CogPMAlignTool(PMTool);

            return param;
        }

        public void SaveTool(string dirPath)
        {
            if (Directory.Exists(dirPath) == false)
                Directory.CreateDirectory(dirPath);

            string fileName = string.Format(@"{0}.vpp", Name);
            string path = Path.Combine(dirPath, fileName);

            if (PMTool == null)
                PMTool = new CogPMAlignTool();

            VisionProFileHelper.SaveTool<CogPMAlignTool>(path, PMTool);
        }

        public void LoadTool(string dirPath)
        {
            string fileName = string.Format("{0}.vpp", Name);
            string path = Path.Combine(dirPath, fileName);

            if (File.Exists(path))
            {
                PMTool = VisionProFileHelper.LoadTool(path) as CogPMAlignTool;
            }
            else
            {
                SaveTool(dirPath);
            }
        }

        public void Dispose()
        {
            if(PMTool != null)
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
    }
}
