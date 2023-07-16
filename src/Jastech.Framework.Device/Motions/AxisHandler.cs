using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Motions
{
    public class AxisHandler
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public List<Axis> AxisList { get; private set; } = new List<Axis>();

        private Task HomeTask { get; set; }

        private CancellationTokenSource HomeTaskCancel;

        private Stopwatch Timeout = new Stopwatch();

        public AxisHandler()
        {

        }

        public AxisHandler(string name)
        {
            Name = name;
        }

        public Axis AddAxis(AxisName name, Motion motion, int axisNo, int homeOrder = -1)
        {
            Axis axis = new Axis(name.ToString(), motion, axisNo);
            axis.HomeOrder = homeOrder;
            AxisList.Add(axis);

            return axis;
        }

        public void AddAxis(List<Axis> axisList)
        {
            AxisList.AddRange(axisList);
        }

        public Axis GetAxis(AxisName name)
        {
            if(AxisList.Where(x => x.Name == name.ToString()).Count() > 0)
                return AxisList.Where(x => x.Name == name.ToString()).First();
        
            return null;
        }

        public void StopMove()
        {
            foreach (Axis axis in AxisList)
                axis.StopMove();
        }

        public void TurnOnServo(bool bOnOff)
        {
            foreach (Axis axis in AxisList)
            {
                if(bOnOff)
                    axis.TurnOnServo();
                else
                    axis.TurnOffServo();
            }
        }

        //public bool WaitHomeMove()
        //{
        //}

        public bool StartHomeMove()
        {
            if (HomeTask != null)
                return false;

            HomeTaskCancel = new CancellationTokenSource();
            HomeTask = new Task(HomeTaskAction, HomeTaskCancel.Token);
            HomeTask.Start();

            return true;
        }

        private void HomeTaskAction()
        {
            for (int homeOrder = -1; homeOrder <= GetMaxHomeOrder(); homeOrder++)
            {
                List<Axis> homeAxisList = GetAxisListByHomeOrder(homeOrder);
                if (homeAxisList.Count > 0)
                {
                    Timeout.Restart();

                    foreach (var axis in homeAxisList)
                    {
                        if (axis.Name == AxisName.Z.ToString())
                            continue;

                        axis.IsHomeFound = false;
                        axis.StartHome();
                    }

                    while (true)
                    {
                        if(HomeTaskCancel.IsCancellationRequested)
                        {
                            StopMove();
                            return;
                        }
                        if (HomeCompleted(homeAxisList))
                            break;

                        Thread.Sleep(300);
                    }
                }
            }
        }

        private int GetMaxHomeOrder()
        {
            return AxisList.Max(x => x.HomeOrder);
        }

        private List<Axis> GetAxisListByHomeOrder(int homeOrder)
        {
            List<Axis> homeAxisList = new List<Axis>();

            foreach (Axis axis in AxisList)
            {
                if (axis.HomeOrder == homeOrder)
                {
                    homeAxisList.Add(axis);
                }
            }

            return homeAxisList;
        }

        private bool HomeCompleted(List<Axis> axisList)
        {
            bool homeCompleted = true;

            foreach (var axis in axisList)
            {
                homeCompleted |= axis.IsHomeFound;
            }
            return homeCompleted;
        }
    }
}
