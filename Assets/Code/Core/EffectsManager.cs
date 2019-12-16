using UnityEngine;
using UnityEngine.VFX;

namespace Greed.Core
{
	public class EffectsManager
	{
		public void Spawn(VisualEffect effect, Vector3 position, Quaternion rotation)
		{
			UnityEngine.Object.Instantiate(effect, position, rotation);
		}
	}
}
