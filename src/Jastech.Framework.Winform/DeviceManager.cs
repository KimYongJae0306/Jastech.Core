using Jastech.Framework.Config;
using Jastech.Framework.Device.Cameras;
using Jastech.Framework.Device.LAFCtrl;
using Jastech.Framework.Device.LightCtrls;
using Jastech.Framework.Device.Motions;
using Jastech.Framework.Device.Plcs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jastech.Framework.Winform
{
    public class DeviceManager
    {
        #region 필드
        private static DeviceManager _instance = null;
        #endregion

        #region 속성
        public CameraHandler CameraHandler { get; private set; }

        public MotionHandler MotionHandler { get; private set; }

        public LightCtrlHandler LightCtrlHandler { get; private set; }

        public LAFCtrlHandler LAFCtrlHandler { get; private set; }

        public PlcHandler PlcHandler { get; private set; }

        private ConfigSet ConfigSet { get; set; }
        #endregion

        #region 대리자
        public delegate void InitializedEventHandler(Type deviceType, bool success);
        #endregion

        #region 이벤트
        public event InitializedEventHandler Initialized;
        #endregion

        #region 생성자
        public DeviceManager()
        {
            CameraHandler = new CameraHandler();
            MotionHandler = new MotionHandler();
            LightCtrlHandler = new LightCtrlHandler();
            LAFCtrlHandler = new LAFCtrlHandler();
            PlcHandler = new PlcHandler();
        }
        #endregion

        #region 메서드
        public static DeviceManager Instance()
        {
            if (_instance == null)
            {
                _instance = new DeviceManager();
            }

            return _instance;
        }

        public void Initialize(ConfigSet configSet)
        {
            ConfigSet = configSet;

            var devices = ConfigSet.Machine.Devices;
            var cameras = devices.Where((d) => d is Camera).Cast<Camera>();
            var motions = devices.Where((d) => d is Motion).Cast<Motion>();
            var lafs = devices.Where((d) => d is LAFCtrl).Cast<LAFCtrl>();
            var lightCtrls = devices.Where((d) => d is LightCtrl).Cast<LightCtrl>();
            var plcs = devices.Where((d) => d is Plc).Cast<Plc>();

            foreach (var camera in cameras)
            {
                CameraHandler.Add(camera);
            }
            foreach (var motion in motions)
            {
                MotionHandler.Add(motion);
            }
            foreach (var laf in lafs)
            {
                LAFCtrlHandler.Add(laf);
            }
            foreach (var lightCtrl in lightCtrls)
            {
                LightCtrlHandler.Add(lightCtrl);
            }
            foreach (var plc in plcs)
            {
                PlcHandler.Add(plc);
            }

            bool cameraSuccess = CameraHandler.Initialize();
            Initialized?.Invoke(typeof(Camera), cameraSuccess);

            bool motionSuccess = MotionHandler.Initialize();
            Initialized?.Invoke(typeof(Motion), motionSuccess);

            bool lafSuccess = LAFCtrlHandler.Initialize();
            Initialized?.Invoke(typeof(LAFCtrl), lafSuccess);

            bool lightCtrlSuccess = LightCtrlHandler.Initialize();
            Initialized?.Invoke(typeof(LightCtrl), lightCtrlSuccess);

            bool plcSuccess = PlcHandler.Initialize();
            Initialized?.Invoke(typeof(Plc), plcSuccess);
        }

        public void Release()
        {
            ReleaseCamera();

            MotionHandler.Release();
            LAFCtrlHandler.Release();
            LightCtrlHandler.Release();
            PlcHandler.Release();
        }

        private void ReleaseCamera()
        {
            if (CameraHandler == null)
                return;

            List<CameraMil> milCameraList = new List<CameraMil>();
            foreach (var camera in CameraHandler)
            {
                if (camera is CameraMil)
                {
                    milCameraList.Add(camera as CameraMil);
                }
            }

            if (milCameraList.Count > 0)
            {
                var maxSystemNum = milCameraList.Select(x => x.SystemNum).Max();
                List<CameraMil>[] sortCameraList = new List<CameraMil>[maxSystemNum + 1];

                foreach (var milCamera in milCameraList)
                {
                    if (sortCameraList[milCamera.SystemNum] == null)
                        sortCameraList[milCamera.SystemNum] = new List<CameraMil>();

                    sortCameraList[milCamera.SystemNum].Add(milCamera);
                }

                foreach (var milCamera in sortCameraList)
                {
                    milCamera.Sort((f1, f2) => f1.SystemNum.CompareTo(f2.DigitizerNum));
                }

                foreach (var milCamera in milCameraList)
                {
                    milCamera.Release();
                }
            }
            
            CameraHandler.Release();

        }
        #endregion
    }
}
