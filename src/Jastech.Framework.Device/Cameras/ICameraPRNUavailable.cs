namespace Jastech.Framework.Device.Cameras
{
    public interface ICameraPRNUavailable
    {
        void SetStrobeMode(StrobeMode mode);

        void SetStrobeDuration(int us);

        void SetStrobeCurrent(int channel, int value);

        void SetStrobeBrightness(int channel, int value);

        void SetOutputFrequency(int value);

        void SetFFCEnable(int value);

        void SetFFCCalibration(int value);

        void SetPRNUCalibration(int value);
    }

    public enum StrobeMode
    {
        Off = 0,
        StrobeDuration = 1,
        TriggerPulse = 2,
        SuccessiveHighPulse = 3,
    }
}
