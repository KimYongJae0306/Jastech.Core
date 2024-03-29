﻿using Newtonsoft.Json;
using System;
using static Jastech.Framework.Device.Motions.AxisMovingParam;

namespace Jastech.Framework.Device.LAFCtrl
{
    public abstract partial class LAFCtrl : IDevice, IDisposable
    {
        #region 속성
        [JsonIgnore]
        public LAFStatus Status { get; set; } = new LAFStatus();
        #endregion

        #region 이벤트
        public event LAFEventHandler DataReceived;
        #endregion

        #region 델리게이트
        public delegate void LAFEventHandler(string name, byte[] data);
        #endregion

        #region 생성자
        public LAFCtrl(string name)
        {
            Name = name;
        }
        #endregion

        #region 메서드
        public abstract void SetMotionRelativeMove(Direction direction, double value);

        public abstract void SetMotionAbsoluteMove(double value);

        public abstract void SetMotionNegativeLimit(double value);

        public abstract void SetMotionPositiveLimit(double value);

        public abstract void SetAccDec(int value);

        public abstract void SetMotionMaxSpeed(double value);

        public abstract void SetDefaultParameter();

        public abstract void SetMotionZeroSet();

        public abstract void SetMotionStop();

        public abstract void SetCenterOfGravity(int value);

        public abstract void SetTrackingOnOFF(bool isOn);

        public abstract void SetLaserOnOff(bool isOn);

        public abstract void SetMotionEnable(bool isOn);

        public abstract void SetVroOnOff(bool isOn);

        public abstract void SetYWindow(int start, int width);

        public abstract void SetLowerReturndB(double value);

        public abstract void SetUpperReturndB(double value);

        protected void OnLAFReceived(byte[] data)
        {
            DataReceived?.Invoke(Name, data);
        }
        #endregion
    }

    public abstract partial class LAFCtrl : IDevice
    {
        #region 속성
        [JsonProperty]
        public string Name { get; protected set; }

        [JsonProperty]
        public string AxisName { get; set; }

        [JsonProperty]
        public double ResolutionAxisZ { get; set; } = 10000.0;      // 1=0.1um, 10=1um 100 =10um 1000=100um 10000=1mm 

        [JsonProperty]
        public double HomePosition_mm { get; set; } = 0.025;

        [JsonProperty]
        public int MaxSppedAxisZ { get; set; } = 20;            // Hz

        [JsonProperty]
        public int AccDec { get; set; } = 15;            // Hz

        [JsonProperty]
        public bool YWindowOnOff { get; set; } = false;

        [JsonProperty]
        public int YWindowStart { get; set; } = 200;

        [JsonProperty]
        public int YWindowWidth { get; set; } = 80;
        #endregion

        #region 메서드
        public virtual bool Initialize()
        {
            return true;
        }

        public virtual bool IsConnected()
        {
            return false;
        }

        public virtual bool Release()
        {
            return true;
        }
        #endregion
    }
    public abstract partial class LAFCtrl : IDisposable
    {
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                }

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                disposedValue = true;
            }
        }

        // // TODO: 비관리형 리소스를 해제하는 코드가 'Dispose(bool disposing)'에 포함된 경우에만 종료자를 재정의합니다.
        // ~Camera()
        // {
        //     // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
            Dispose(disposing: true);
            //GC.SuppressFinalize(this);
        }
    }

    public class LAFStatus
    {
        #region 필드
        private object _lock { get; set; } = new object();
        #endregion

        #region 속성
        public bool IsLaserOn { get; set; }

        public bool IsTrackingOn { get; set; }

        public int CenterofGravity { get; set; }

        public double MPosPulse { get; set; }

        public bool IsNegativeLimit { get; set; }

        public bool IsPositiveLimit { get; set; }

        public bool IsBusy { get; set; }

        public bool NeedHomming { get; set; } = true;

        public double ReturndB { get; set; }
        #endregion
    }
}
