using Jastech.Framework.Device.Motions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Structure
{

    #region 필드
    #endregion

    #region 속성
    #endregion

    #region 이벤트
    #endregion

    #region 델리게이트
    #endregion

    #region 생성자
    #endregion

    #region 메서드
    #endregion

    public class TeachingPosition
    {
        [JsonProperty]
        public string Name { get; set; } = string.Empty;

        [JsonProperty]
        public string Description { get; set; } = string.Empty;
        
        [JsonProperty]
        public double TargetPosition { get; set; } = 0.0;

        [JsonProperty]
        public AxisMovingParam MovingParam { get; set; } = new AxisMovingParam();

        public TeachingPosition(string name, AxisMovingParam param, string description)
        {
            Name = name;
            MovingParam = param;
            Description = description;
        }
    }
}
