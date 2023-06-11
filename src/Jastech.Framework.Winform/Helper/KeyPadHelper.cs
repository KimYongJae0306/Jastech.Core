using Jastech.Framework.Winform.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Helper
{
    public static class KeyPadHelper
    {
        public static int SetLabelIntegerData(Label label)
        {
            double prevData = Convert.ToDouble(label.Text);

            KeyPadForm keyPadForm = new KeyPadForm();
            keyPadForm.PreviousValue = (double)prevData;
            keyPadForm.ShowDialog();

            int inputData = Convert.ToInt32(keyPadForm.PadValue);

            label.Text = inputData.ToString();

            return inputData;
        }

        public static double SetLabelDoubleData(Label label)
        {
            double prevData = Convert.ToDouble(label.Text);

            KeyPadForm keyPadForm = new KeyPadForm();
            keyPadForm.PreviousValue = prevData;
            keyPadForm.ShowDialog();

            double inputData = keyPadForm.PadValue;

            label.Text = inputData.ToString();

            return inputData;
        }
    }
}
