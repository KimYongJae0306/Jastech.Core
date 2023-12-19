using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.PMAlign;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms
{
    public static class VisionProHelper
    {
        public static void InitMemory()
        {
            ICogImage cogImage = new CogImage8Grey(10, 10);
            // CogBlobTool 최초 실행 시 검사 시간 지연되는 문제 있어서 미리 1회 검사 진행
            CogBlobTool blobTool = new CogBlobTool();
            blobTool.InputImage = cogImage;
            blobTool.Run();

            blobTool.Dispose();
        }

        public static void DisposeTool(CogPMAlignTool tool)
        {
            if (tool != null)
            {
                if (tool.Pattern.TrainImage != null)
                {
                    if (tool.Pattern.TrainImage is CogImage8Grey grey)
                        grey.Dispose();
                    if (tool.Pattern.TrainImage is CogImage24PlanarColor color)
                        color.Dispose();
                }

                tool.Pattern.TrainImage = null;
                tool.Pattern.Dispose();
                tool.Pattern = null;

                if (tool.InputImage != null)
                {
                    if (tool.InputImage is CogImage8Grey grey)
                        grey.Dispose();
                    if (tool.InputImage is CogImage24PlanarColor color)
                        color.Dispose();
                }

                tool.InputImage = null;
                tool.RunParams.Dispose();
                tool.RunParams = null;

                if (tool.Results != null)
                    tool.Results.Dispose();

                tool.Dispose();
            }

            tool = null;
        }
    }
}
