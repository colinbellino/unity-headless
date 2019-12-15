using UnityEngine.VFX;

namespace Greed.Core
{
	public class EffectsManager
	{
		public void Spawn(VisualEffect effect)
		{
			UnityEngine.Object.Instantiate(effect);
		}
	}
}
