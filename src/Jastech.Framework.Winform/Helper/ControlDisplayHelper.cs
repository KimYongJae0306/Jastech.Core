using System;
using System.Drawing;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Helper
{
    public static class ControlDisplayHelper
    {
        public static void DisposeDisplay<T>(T control) where T : Control
        {
            if (control != null)
            {
                var property = control.GetType().GetProperty("Image");
                if (property != null)
                {
                    var image = (Image)property.GetValue(control);
                    image?.Dispose();
                }
            }
        }

        public static void DisposeChildControls<T>(T control) where T : Control
        {
            // ControlCollection RAM 누수 방지
            foreach (var childControl in control.Controls)
            {
                if (childControl is IDisposable disposableControl)
                    disposableControl.Dispose();
            }
            if (control is IDisposable)
                control.Dispose();
        }
    }
}
