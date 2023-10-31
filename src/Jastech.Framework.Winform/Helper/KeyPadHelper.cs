using Jastech.Framework.Winform.Forms;
using System;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Helper
{
    public static class KeyPadHelper
    {
        public static int SetLabelIntegerData(Control control)
        {
            double prevData = 0;
            if (control.Text != "")
                prevData = Convert.ToDouble(control.Text);

            KeyPadForm keyPadForm = new KeyPadForm();
            keyPadForm.PreviousValue = prevData;
            keyPadForm.ShowDialog();

            int inputData = Convert.ToInt32(keyPadForm.PadValue);
            control.Text = inputData.ToString();

            return inputData;
        }

        public static double SetLabelDoubleData(Control control)
        {
            double prevData = 0;
            if (control.Text != "")
                prevData = Convert.ToDouble(control.Text);

            KeyPadForm keyPadForm = new KeyPadForm();
            keyPadForm.PreviousValue = prevData;
            keyPadForm.ShowDialog();

            double inputData = Convert.ToDouble(keyPadForm.PadValue);
            control.Text = inputData.ToString();
            
            return inputData;
        }

        public static float SetLabelFloatData(Control control)
        {
            float prevData = 0;
            if (control.Text != "")
                prevData = Convert.ToSingle(control.Text);

            KeyPadForm keyPadForm = new KeyPadForm();
            keyPadForm.PreviousValue = prevData;
            keyPadForm.ShowDialog();

            float inputData =  Convert.ToSingle(keyPadForm.PadValue);
            control.Text = inputData.ToString();

            return inputData;
        }
    }
}
