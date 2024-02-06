using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Helper
{
    public static class ControlHelper
    {
        public static Control[] GetAllControlsUsingRecursive(Control containerControl)
        {
            List<Control> controlList = new List<Control>();

            foreach (Control control in containerControl.Controls)
            {
                controlList.Add(control);

                if (control.Controls.Count > 0)
                    controlList.AddRange(GetAllControlsUsingRecursive(control));
            }

            return controlList.ToArray();
        }

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
