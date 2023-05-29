using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Jastech.Framework.Imaging.VisionAlgorithms;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms
{
    public class VisionProBlob : CogVision
    {
        #region 필드
        public CogBlobTool BlobTool { get; set; }
        #endregion

        #region 속성
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        #endregion

        #region 메서드
        public VisionProBlobResult Run(ICogImage image, VisionProBlobParam blobParam, bool debug = false)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            
            blobParam.SetInputImage(image);
            var resultList = blobParam.Run();
            if (resultList == null)
                return null;

            VisionProBlobResult result = new VisionProBlobResult();
                 
            CogBlobResultCollection blobResults = resultList.GetBlobs();

            List<BlobPos> findBlobList = new List<BlobPos>();

            foreach (var blob in blobResults)
            {
                CogBlobResult cogBlob = blob as CogBlobResult;
                List<Point> chainList = new List<Point>();
                //if (debug)
                //{
                //    var boundary = cogBlob.GetBoundary().EnclosingRectangle(CogCopyShapeConstants.All);
                //    var pointCount = boundary.GetVertices().Length / 2;
                //    for (int i = 0; i < pointCount; i++)
                //    {
                //        double x = boundary.GetVertexX(i);
                //        double y = boundary.GetVertexY(i);
                //        chainList.Add(new Point((int)x, (int)y));
                //    }
                //}

                //var cogRect = cogBlob.GetBoundingBox(CogBlobAxisConstants.PixelAlignedNoExclude);
                //Rectangle boundingRect = VisionProImageHelper.ConvertAffineRectToRect(cogRect);
                double centerX = cogBlob.GetBoundingBox(CogBlobAxisConstants.PixelAligned).CenterX;
                double centerY = cogBlob.GetBoundingBox(CogBlobAxisConstants.PixelAligned).CenterY;
                double width = cogBlob.GetBoundingBox(CogBlobAxisConstants.PixelAligned).SideXLength;
                double height = cogBlob.GetBoundingBox(CogBlobAxisConstants.PixelAligned).SideYLength;
                double x = centerX - (width / 2);
                double y = centerY - (height / 2);
                Rectangle boundingRect = new Rectangle((int)x, (int)y, (int)width, (int)height);
                BlobPos pos = new BlobPos
                {
                    Area = cogBlob.Area,
                    CenterX = cogBlob.CenterOfMassX,
                    CenterY = cogBlob.CenterOfMassY,
                    Points = chainList,
                    BoundingRect = boundingRect,
                };
                findBlobList.Add(pos);
            }
            sw.Stop();

            result.TactTime = sw.ElapsedMilliseconds;
            result.BlobList = findBlobList;

            return result;
        }
        #endregion
    }
}
