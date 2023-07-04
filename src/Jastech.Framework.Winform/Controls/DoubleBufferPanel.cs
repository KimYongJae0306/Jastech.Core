using System.Windows.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public class DoubleBufferPanel : Panel
    {
        public DoubleBufferPanel()
        {
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            UpdateStyles();
        }
    }
}
