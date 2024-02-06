using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
