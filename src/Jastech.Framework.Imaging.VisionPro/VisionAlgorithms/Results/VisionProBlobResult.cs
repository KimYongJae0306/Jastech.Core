using Cognex.VisionPro;
using Jastech.Framework.Imaging.Result;
using Jastech.Framework.Imaging.VisionAlgorithms;
using System.Collections.Generic;
using System.Linq;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results
{
    public class VisionProBlobResult : VisionResult
    {
        #region 속성
        public List<BlobPos> BlobList { get; set; } = new List<BlobPos>();

        public CogCompositeShape ResultGraphics { get; set; }
        #endregion

        public void Dispose()
        {
            ResultGraphics?.Dispose();
        }

        public VisionProBlobResult DeepCopy()
        {
            VisionProBlobResult blobResult = new VisionProBlobResult();
            blobResult.BlobList = BlobList.Select(x => x.DeepCopy()).ToList();
            blobResult.ResultGraphics = ResultGraphics.CopyBase(CogCopyShapeConstants.GeometryOnly) as CogCompositeShape; // 인자 확인 필요

            return blobResult;
        }
    }
}
