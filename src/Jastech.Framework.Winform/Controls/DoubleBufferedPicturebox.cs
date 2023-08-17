using System.Windows.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public class DoubleBufferedPicturebox : PictureBox
    {
        public DoubleBufferedPicturebox()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
        }
    }
}
