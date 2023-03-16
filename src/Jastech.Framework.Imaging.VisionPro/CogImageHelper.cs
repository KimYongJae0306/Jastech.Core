using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro
{
    public static class CogImageHelper
    {
        public static ICogImage FileOpen(string fileName)
        {
            CogImageFile cogImageFile = new CogImageFile();

            cogImageFile.Open(fileName, CogImageFileModeConstants.Read);

            ICogImage image = cogImageFile[0];
            cogImageFile.Close();

            return image;
        }
    }
}
