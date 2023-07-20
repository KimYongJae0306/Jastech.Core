using Jastech.Framework.Winform.Forms;
using System;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Helper
{
    public static class KeyPadHelper
    {
        public static int SetLabelIntegerData(Label label)
        {
            double prevData = 0;
            if (label.Text != "")
                prevData = Convert.ToDouble(label.Text);

            KeyPadForm keyPadForm = new KeyPadForm();
            keyPadForm.PreviousValue = (double)prevData;
            keyPadForm.ShowDialog();

            int inputData = Convert.ToInt32(keyPadForm.PadValue);

            label.Text = inputData.ToString();

            return inputData;
        }

        public static double SetLabelDoubleData(Label label)
        {
            double prevData = 0;
            if (label.Text != "")
                prevData = Convert.ToDouble(label.Text);

            KeyPadForm keyPadForm = new KeyPadForm();
            keyPadForm.PreviousValue = prevData;
            keyPadForm.ShowDialog();

            double inputData = keyPadForm.PadValue;

            label.Text = inputData.ToString();

            return inputData;
        }

        public static float SetLabelFloatData(Label label)
        {
            float prevData = 0;
            if (label.Text != "")
                prevData = Convert.ToSingle(label.Text);

            KeyPadForm keyPadForm = new KeyPadForm();
            keyPadForm.PreviousValue = prevData;
            keyPadForm.ShowDialog();

            float inputData = Convert.ToSingle(keyPadForm.PadValue);

            label.Text = inputData.ToString();

            return inputData;
        }
    }
}
