using UnityEngine;

namespace Greed.Unity
{
	public class AutoDestroyVisualEffect : MonoBehaviour
	{
		[SerializeField] private float _destroyInSeconds = 1f;

		public void Start()
		{
			Destroy(gameObject, _destroyInSeconds);
		}
	}
}
