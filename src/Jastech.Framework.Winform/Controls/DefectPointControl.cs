using System;
using System.Drawing;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Controls
{
    //public enum ElectrodeDefectType             //어딯로 빼지..
    //{
    //    // 흑,백계
    //    DarkLine,       // 흑선
    //    DarkPoint,      // 흑점
    //    DarkScratch,    // 긁힘 (어두움)
    //    BrightLine,     // 백선
    //    BrightPoint,    // 백점
    //    BrightScratch,  // 긁힘 (밝음)

    //    // 이물계
    //    Dust,           // 먼지
    //    Labeling,       // 라벨링
    //    Fingerprint,    // 지문
    //    ForeignMatter,  // 이물질
    //    Stain,          // 얼룩
    //    Tape,           // 테이프

    //    // 표면 형상계
    //    Blister,        // 물집
    //    Bubble,         // 기포
    //    Coating,        // 코팅 이상
    //    Crack,          // 균열
    //    Tear,           // 찢김
    //    Pattern,        // 무늬
    //    Press,          // 압착 이상
    //    Wrinkle,        // 주름
    //}

    //public class DefectDefine               //어디로 빼지2
    //{
    //    public static Dictionary<ElectrodeDefectType, Color> Colors = new Dictionary<ElectrodeDefectType, Color>
    //    {
    //        // 흑,백계
    //        { ElectrodeDefectType.DarkLine, Color.FromArgb(32,32,127) },
    //        { ElectrodeDefectType.DarkPoint, Color.FromArgb(32,32,127) },
    //        { ElectrodeDefectType.DarkScratch, Color.FromArgb(32,32,127) },
    //        { ElectrodeDefectType.BrightLine, Color.FromArgb(192,192,127) },
    //        { ElectrodeDefectType.BrightPoint, Color.FromArgb(127,192,192) },
    //        { ElectrodeDefectType.BrightScratch, Color.FromArgb(127,192,192) },
    //        // 이물계
    //        { ElectrodeDefectType.Dust, Color.Red },
    //        { ElectrodeDefectType.Labeling, Color.Red },
    //        { ElectrodeDefectType.Fingerprint, Color.Red },
    //        { ElectrodeDefectType.ForeignMatter, Color.Red },
    //        { ElectrodeDefectType.Stain, Color.Red },
    //        { ElectrodeDefectType.Tape, Color.Red },
    //        // 표면 형상계
    //        { ElectrodeDefectType.Blister, Color.Red },
    //        { ElectrodeDefectType.Bubble, Color.Red },
    //        { ElectrodeDefectType.Coating, Color.Red },
    //        { ElectrodeDefectType.Crack, Color.Red },
    //        { ElectrodeDefectType.Tear, Color.Red },
    //        { ElectrodeDefectType.Pattern, Color.Red },
    //        { ElectrodeDefectType.Press, Color.Red },
    //        { ElectrodeDefectType.Wrinkle, Color.Red },
    //    };
    //}

    public partial class DefectPointControl : UserControl
    {
        #region 필드
        #endregion

        #region 속성
        public int Index { get; set; }
        public PointF Coord { get; set; }
        public Color DisplayColor { get; set; } = Color.Red;            // Dictionary<ElectrodeDefectType, Color> 로 따로 정의해ㅑ야
        public bool IsSelected { get; set; }

        public int DefectLevel { get; set; }
        //public ElectrodeDefectType DefectType { get; set; }         //LineType은 모아서 줄로 그릴까
        #endregion


        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public DefectPointControl()
        {
            InitializeComponent();
            base.CreateParams.ExStyle |= 0x20;
            SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }
        #endregion

        #region 메서드

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillEllipse(new SolidBrush(DisplayColor), new RectangleF(0.5f, 0.5f, 6, 6));
        }

        private void DefectPoint_Load(object sender, EventArgs e)
        {
        }

        private void DefectPoint_Click(object sender, EventArgs e)
        {
            IsSelected = true;
            DisplayColor = Color.FromArgb(Color.Gray.ToArgb() - DisplayColor.ToArgb());
            Invalidate();
        }
        #endregion
    }
}
