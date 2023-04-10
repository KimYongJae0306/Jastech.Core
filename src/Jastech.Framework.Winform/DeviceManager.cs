using Jastech.Framework.Config;
using Jastech.Framework.Device.Cameras;
using Jastech.Framework.Device.LightCtrls;
using Jastech.Framework.Device.Motions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var lightCtrls = devices.Where((d) => d is LightCtrl).Cast<LightCtrl>();

            foreach (var camera in cameras)
            {
                CameraHandler.Add(camera);
            }
            foreach (var motion in motions)
            {
                MotionHandler.Add(motion);
            }
            foreach (var lightCtrl in lightCtrls)
            {
                LightCtrlHandler.Add(lightCtrl);
            }

            bool cameraSuccess = CameraHandler.Initialize();
            Initialized?.Invoke(typeof(Camera), cameraSuccess);

            bool motionSuccess = MotionHandler.Initialize();
            Initialized?.Invoke(typeof(Motion), cameraSuccess);

            bool lightCtrlSuccess = LightCtrlHandler.Initialize();
            Initialized?.Invoke(typeof(LightCtrl), lightCtrlSuccess);
        }

        public void Release()
        {
            CameraHandler.Release();
            MotionHandler.Release();
            LightCtrlHandler.Release();
        }
        #endregion
    }
}
