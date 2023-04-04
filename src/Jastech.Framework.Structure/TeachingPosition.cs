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

        [JsonIgnore]
        private AxisHandler AxisHandler { get; set; } = null;

        [JsonProperty]
        public List<TeachingAxisInfo> AxisInfoList = new List<TeachingAxisInfo>();

        public TeachingPosition(string name, string description, AxisHandler axisHandler)
        {
            Name = name;
            Description = description;

            foreach (var axis in axisHandler.AxisList)
            {
                AddAxisParam(axis);
            }
        }

        public void AddAxisParam(Axis axis)
        {
            TeachingAxisInfo info = new TeachingAxisInfo
            {
                Name = axis.Name,
            };

            AxisInfoList.Add(info);
        }

        public double GetTargetPosition(string axisName)
        {
            return AxisInfoList.Where(x => x.Name == axisName).First().TargetPosition;
        }

        public void SetTargetPosition(string axisName, double targetPosition)
        {
            AxisInfoList.Where(x => x.Name == axisName).First().TargetPosition = targetPosition;
        }

        public AxisMovingParam GetMovingParams(string axisName)
        {
            return AxisInfoList.Where(x => x.Name == axisName).First().MovingParam;
        }

        public void SetMovingParams(string axisName, AxisMovingParam param)
        {
            AxisInfoList.Where(x => x.Name == axisName).First().MovingParam = param;
        }
    }

    public class TeachingAxisInfo
    {
        [JsonProperty]
        public string Name { get; set; } = "";

        [JsonProperty]
        public double TargetPosition { get; set; } = 0.0;

        [JsonProperty]
        public AxisMovingParam MovingParam { get; set; } = new AxisMovingParam();
    }
}
