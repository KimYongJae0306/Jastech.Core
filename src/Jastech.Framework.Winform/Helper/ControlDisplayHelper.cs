using System.Drawing;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Helper
{
    public static class ControlDisplayHelper
    {
        public static void DisposeDisplay<T>(T control) where T : Control
        {
            if(control != null)
            {
                var property = control.GetType().GetProperty("Image");
                if(property != null)
                {
                    var image = (Image)property.GetValue(control);
                    image?.Dispose();
                }
            }
        }
    }
}
