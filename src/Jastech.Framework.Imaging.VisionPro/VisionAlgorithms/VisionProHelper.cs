using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
