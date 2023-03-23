using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms
{
    public abstract class CogVision
    {
        public abstract void Save(string filePath);

        public abstract void Load(string filePath);
    }
}
