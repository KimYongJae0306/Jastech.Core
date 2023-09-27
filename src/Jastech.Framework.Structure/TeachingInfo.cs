using Jastech.Framework.Device.Motions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Jastech.Framework.Structure
{
    public class TeachingInfo
    {
        [JsonProperty]
        public string Name { get; set; } = string.Empty;

        [JsonProperty]
        public string Description { get; set; } = string.Empty;

        [JsonProperty]
        private List<TeachingAxisInfo> AxisInfoList { get; set; } = new List<TeachingAxisInfo>();

        public void CreateTeachingInfo(string name, string description, AxisHandler axisHandler)
        {
            Name = name;
            Description = description;

            foreach (var axis in axisHandler.GetAxisList())
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

        public double GetTargetPosition(AxisName axisName)
        {
            return AxisInfoList.Where(x => x.Name == axisName.ToString()).First().TargetPosition;
        }

        public void SetTargetPosition(AxisName name, double targetPosition)
        {
            AxisInfoList.Where(x => x.Name == name.ToString()).First().TargetPosition = targetPosition;
        }

        public double GetOffset(string axisName)
        {
            return AxisInfoList.Where(x => x.Name == axisName).First().Offset;
        }

        public double GetOffset(AxisName axisName)
        {
            return AxisInfoList.Where(x => x.Name == axisName.ToString()).First().Offset;
        }

        public void SetOffset(AxisName name, double offset)
        {
            AxisInfoList.Where(x => x.Name == name.ToString()).First().Offset = offset;
        }

        public double GetCenterOfGravity(string axisName)
        {
            return AxisInfoList.Where(x => x.Name == axisName).First().CenterOfGravity;
        }

        public AxisMovingParam GetMovingParam(string axisName)
        {
            return AxisInfoList.Where(x => x.Name == axisName).First().MovingParam;
        }

        public int GetCenterOfGravity(AxisName axisName)
        {
            return AxisInfoList.Where(x => x.Name == axisName.ToString()).First().CenterOfGravity;
        }

        public void SetCenterOfGravity(AxisName name, int centerOfGravity)
        {
            AxisInfoList.Where(x => x.Name == name.ToString()).First().CenterOfGravity = centerOfGravity;
        }

        public TeachingAxisInfo GetAxisInfo(AxisName name)
        {
            return AxisInfoList.Where(x => x.Name == name.ToString()).First();
        }

        public AxisMovingParam GetMovingParams(AxisName name)
        {
            return AxisInfoList.Where(x => x.Name == name.ToString()).First().MovingParam;
        }

        public void SetMovingParams(AxisName name, AxisMovingParam param)
        {
            AxisInfoList.Where(x => x.Name == name.ToString()).First().MovingParam = param;
        }

        public TeachingInfo DeepCopy()
        {
            TeachingInfo param = new TeachingInfo();

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
        public int CenterOfGravity { get; set; } = 0;

        [JsonProperty]
        public AxisMovingParam MovingParam { get; set; } = new AxisMovingParam();

        public TeachingAxisInfo DeepCopy()
        {
            TeachingAxisInfo info = new TeachingAxisInfo();

            info.Name = Name;
            info.TargetPosition = TargetPosition;
            info.Offset = Offset;
            info.CenterOfGravity = CenterOfGravity;

            info.MovingParam = MovingParam.DeepCopy();

            return info;
        }
    }
}
