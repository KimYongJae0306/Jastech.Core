using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters
{
    public class VisionProPointMarkerParam
    {
        #region 이벤트
        public event SetOriginDelegate SetOriginEventHandler;
        #endregion

        #region 델리게이트
        public delegate void SetOriginDelegate(CogTransform2DLinear originPoint);
        #endregion

        public CogPointMarker PointMarker { get; set; } = null;

        public CogTransform2DLinear GetOriginPoint()
        {
            if (PointMarker == null)
                return null;

            //double x = 0.0;
            //double y = 0.0;
            //double rotation = 0.0;
            //int size = 0;

            //var tqtqwte = PointMarker.X;
            //var wqerqw = PointMarker.Y;

            //PointMarker.GetCenterRotationSize(out x, out y, out rotation, out size);
            //CogTransform2DLinear aa = new CogTransform2DLinear();
            //aa.TranslationX = x;
            //aa.TranslationY = y;

            return PointMarker.GetParentFromChildTransform() as CogTransform2DLinear;
        }

        public void SetOriginPoint(double x, double y, double rotation = 0, int size = 100)
        {
            if(PointMarker != null)
                PointMarker.Changed -= PointMarker_Changed;

            PointMarker = new CogPointMarker();
            PointMarker.Interactive = true;
            PointMarker.GraphicDOFEnable = CogPointMarkerDOFConstants.All;
            PointMarker.GraphicType = CogPointMarkerGraphicTypeConstants.Cross;
            PointMarker.SetCenterRotationSize(x, y, rotation, size);
            PointMarker.Changed += PointMarker_Changed;
        }

        private void PointMarker_Changed(object sender, CogChangedEventArgs e)
        {
            SetOriginEventHandler?.Invoke(GetOriginPoint());
        }

        public CogGraphicInteractiveCollection GetCurrentRecord()
        {
            if (PointMarker == null)
                return null;

            CogGraphicInteractiveCollection collect = new CogGraphicInteractiveCollection();
            collect.Add(PointMarker);

            return collect;
        }
    }
}
