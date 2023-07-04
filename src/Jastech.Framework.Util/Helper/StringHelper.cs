using System;
using System.Drawing;
using System.Text;

namespace Jastech.Framework.Util.Helper
{
    public static class StringHelper
    { 
        public static byte[] StringToByte(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public static string ByteToString(byte[] strByte)
        {
            return Encoding.Default.GetString(strByte);
        }

        public static byte[] HexStringToByteArray(string hexString)
        {
            hexString = hexString.Replace(" ", string.Empty);

            byte[] txtInByte = new byte[hexString.Length / 2];
            int j = 0;
            for (int i = 0; i < hexString.Length; i += 2)
            {
                txtInByte[j++] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }

            return txtInByte;
        }

        public static Point GetTextPoint(TextPointDirection direction, Point p1, Point p2, Point p3, Point p4)
        {
            int minX = GetMin(p1.X, p2.X, p3.X, p4.X);
            int maxX = GetMax(p1.X, p2.X, p3.X, p4.X);

            int minY = GetMin(p1.Y, p2.Y, p3.Y, p4.Y);
            int maxY = GetMax(p1.Y, p2.Y, p3.Y, p4.Y);

            int intervalX = Math.Abs(maxX - minX);
            int intervalY = Math.Abs(maxY - minY);

            if (direction == TextPointDirection.BottomCenter)
                return new Point(minX + (intervalX / 2), maxY);


            return new Point(minX + (intervalX / 2), minY + (intervalY / 2));
        }

        public static int GetMin(params int[] values)
        {
            int min = int.MaxValue;
            foreach (var value in values)
            {
                if (value <= min)
                    min = value;
            }
            return min;
        }

        public static int GetMax(params int[] values)
        {
            int min = int.MinValue;
            foreach (var value in values)
            {
                if (value >= min)
                    min = value;
            }
            return min;
        }
    }

    public enum TextPointDirection
    {
        BottomCenter,
    }
}
