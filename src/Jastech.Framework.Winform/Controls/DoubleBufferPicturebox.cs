using System.Windows.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public class DoubleBufferPicturebox : PictureBox
    {
        public DoubleBufferPicturebox()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
        }
    }
}
