using UnityEngine;
using UnityEngine.VFX;

namespace Greed.Core
{
	public class VisualEffectsSpawner
	{
		public void Create(VisualEffect effect, Vector3 position, Quaternion rotation)
		{
			Object.Instantiate(effect, position, rotation);
		}
	}
}
