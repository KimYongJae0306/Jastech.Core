namespace Jastech.Framework.Imaging.Result
{
    public class VisionResult
    {
		public long TactTime { get; set; }
    }

    public enum Judgement
    {
        None,
        OK,
        NG,
        FAIL,
    }
}
