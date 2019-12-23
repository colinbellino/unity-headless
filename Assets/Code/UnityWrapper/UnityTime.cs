namespace Greed.UnityWrapper
{
	public class UnityTime : ITime
	{
		public float Time => UnityEngine.Time.time;
		public float DeltaTime => UnityEngine.Time.deltaTime;
		public float FixedDeltaTime => UnityEngine.Time.fixedDeltaTime;
	}
}
