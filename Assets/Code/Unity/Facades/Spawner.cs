using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class Spawner : MonoBehaviour
	{
		private SpawnableFactory _factory;

		[Inject]
		public void Construct(SpawnableFactory factory)
		{
			_factory = factory;
		}

		public void Start()
		{
			var instance = _factory.Create();
			instance.transform.position = transform.position;
		}
	}
}
