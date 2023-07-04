namespace Jastech.Framework.Device.Motions
{
    public class MotionHandler : DeviceHandler<Motion>
    {
        #region 메서드
        public void TurnOnServo()
        {
            foreach (var motion in Devices)
            {
                for (int axisIndex = 0; axisIndex < motion.AxisNumber; ++axisIndex)
                {
                    motion.TurnOnServo(axisIndex, true);
                }
            }
        }

        public void TurnOffServo()
        {
            foreach (var motion in Devices)
            {
                for (int axisIndex = 0; axisIndex < motion.AxisNumber; ++axisIndex)
                {
                    motion.TurnOnServo(axisIndex, false);
                }
            }
        }
        #endregion
    }
}
