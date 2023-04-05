using Jastech.Framework.Config;
using Jastech.Framework.Device.Cameras;
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

            foreach (var camera in cameras)
            {
                CameraHandler.Add(camera);
            }
            foreach (var motion in motions)
            {
                MotionHandler.Add(motion);
            }
            
            bool cameraSuccess = CameraHandler.Initialize();
            Initialized?.Invoke(typeof(Camera), cameraSuccess);

            bool motionSuccess = MotionHandler.Initialize();
            Initialized?.Invoke(typeof(Motion), cameraSuccess);
        }

        public void Release()
        {
            CameraHandler.Release();
            MotionHandler.Release();
        }

        //public Motion GetMotion()
        //{
        //    var motion = DeviceManager.Instance().MotionHandler.First();

        //    return motion;
        //}

        public Camera GetCamera()
        {
            var camera = DeviceManager.Instance().CameraHandler.First();

            return camera;
        }
        #endregion
    }
}
