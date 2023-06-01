using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Winform.VisionPro.Helper
{
    public static class CogDisplayHelper
    {
        public static void DisposeDisplay(CogRecordDisplay display)
        {
            if (display.Image is CogImage8Grey grayImage)
            {
                grayImage.Dispose();
                grayImage = null;
            }
            if (display.Image is CogImage24PlanarColor colorImage)
            {
                colorImage.Dispose();
                colorImage = null;
            }
        }

        public static void DisposeDisplay(CogDisplay display)
        {
            if (display.Image is CogImage8Grey grayImage)
            {
                grayImage.Dispose();
                grayImage = null;
            }
            if (display.Image is CogImage24PlanarColor colorImage)
            {
                colorImage.Dispose();
                colorImage = null;
            }
        }
    }
}
