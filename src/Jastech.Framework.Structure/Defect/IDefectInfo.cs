using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Jastech.Framework.Structure.Defect.DefectDefine;

namespace Jastech.Framework.Structure.Defect
{
    public interface IDefectInfo
    {
        int Index { get; set; }

        int DefectLevel { get; set; }

        string Judgement { get; set; }

        DefectTypes DefectType { get; set; }
    }
}
