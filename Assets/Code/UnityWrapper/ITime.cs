namespace Greed.UnityWrapper
{
	public interface ITime
	{
		float Time { get; }
		float DeltaTime { get; }
		float FixedDeltaTime { get; }
	}
}
