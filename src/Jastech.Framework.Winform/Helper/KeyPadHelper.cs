using Jastech.Framework.Winform.Forms;
using System;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Helper
{
    public static class KeyPadHelper
    {
        public static int SetLabelIntegerData(Control control)
        {
            int prevData = 0;
            if (control.Text != "")
                prevData = Convert.ToInt32(control.Text);

            KeyPadForm keyPadForm = new KeyPadForm();
            keyPadForm.PreviousValue = prevData;
            keyPadForm.ShowDialog();

            int inputData = 0;

            try
            {
                inputData = Convert.ToInt32(keyPadForm.PadValue);
                control.Text = inputData.ToString();
            }
            catch (Exception)
            {
                inputData = prevData;
                control.Text = inputData.ToString();
            }

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

            double inputData = 0.0;

            try
            {
                inputData = Convert.ToDouble(keyPadForm.PadValue);
                control.Text = inputData.ToString();
            }
            catch (Exception)
            {
                inputData = prevData;
                control.Text = inputData.ToString();
            }
            
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

            float inputData = 0.0f;

            try
            {
                inputData = Convert.ToSingle(keyPadForm.PadValue);
                control.Text = inputData.ToString();
            }
            catch (Exception)
            {
                inputData = prevData;
                control.Text = inputData.ToString();
            }

            return inputData;
        }
    }
}
