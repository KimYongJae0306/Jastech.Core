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
        public List<TeachingAxisInfo> AxisInfoList = new List<TeachingAxisInfo>();

        public void CreateTeachingPosition(string name, string description, AxisHandler axisHandler)
        {
            Name = name;
            Description = description;

            foreach (var axis in axisHandler.AxisList)
                AddAxisParam(axis);
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

        public void SetTargetPosition(AxisName name, double targetPosition)
        {
            AxisInfoList.Where(x => x.Name == name.ToString()).First().TargetPosition = targetPosition;
        }

        public double GetOffset(string axisName)
        {
            return AxisInfoList.Where(x => x.Name == axisName).First().Offset;
        }

        public void SetOffset(AxisName name, double offset)
        {
            AxisInfoList.Where(x => x.Name == name.ToString()).First().Offset = offset;
        }

        public AxisMovingParam GetMovingParams(string axisName)
        {
            return AxisInfoList.Where(x => x.Name == axisName).First().MovingParam;
        }

        public AxisMovingParam GetMovingParams(AxisName name)
        {
            return AxisInfoList.Where(x => x.Name == name.ToString()).First().MovingParam;
        }

        public void SetMovingParams(AxisName name, AxisMovingParam param)
        {
            AxisInfoList.Where(x => x.Name == name.ToString()).First().MovingParam = param;
        }

        public TeachingPosition DeepCopy()
        {
            TeachingPosition param = new TeachingPosition();

            param.Name = Name;
            param.Description = Description;
            param.AxisInfoList = AxisInfoList.Select(x => x.DeepCopy()).ToList();

            return param;
        }
    }

    public class TeachingAxisInfo
    {
        [JsonProperty]
        public string Name { get; set; } = "";

        [JsonProperty]
        public double TargetPosition { get; set; } = 0.0;

        [JsonProperty]
        public double Offset { get; set; } = 0.0;

        [JsonProperty]
        public AxisMovingParam MovingParam { get; set; } = new AxisMovingParam();

        public TeachingAxisInfo DeepCopy()
        {
            TeachingAxisInfo info = new TeachingAxisInfo();

            info.Name = Name;
            info.TargetPosition = TargetPosition;
            info.Offset = Offset;
            info.MovingParam = MovingParam.DeepCopy();

            return info;
        }
    }
}
