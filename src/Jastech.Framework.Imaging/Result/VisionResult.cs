using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.Result
{
    public class VisionResult
    {
        public Judgement Judgement { get; set; } = Judgement.Fail;
    }

    public enum Judgement
    {
        OK,
        NG,
        Fail,
    }
}
