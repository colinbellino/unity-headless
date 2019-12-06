using UnityEngine;

namespace Greed.UnityWrapper
{
	public class UnityTime : ITime
	{
		public float FixedDeltaTime => Time.fixedDeltaTime;
	}
}
