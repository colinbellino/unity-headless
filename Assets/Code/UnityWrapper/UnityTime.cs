namespace Greed.UnityWrapper
{
	public class UnityTime : ITime
	{
		public float FixedDeltaTime => UnityEngine.Time.fixedDeltaTime;
		public float Time => UnityEngine.Time.time;
	}
}
