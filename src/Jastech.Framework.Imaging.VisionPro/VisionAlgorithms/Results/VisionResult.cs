﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results
{
    public class VisionResult
    {
        public Result Result { get; set; }
    }

    public enum Result
    {
        OK,
        NG,
        Fail,
    }
}
