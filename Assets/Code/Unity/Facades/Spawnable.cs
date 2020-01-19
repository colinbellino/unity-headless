using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class Spawnable : MonoBehaviour { }

	public class SpawnableFactory : PlaceholderFactory<Spawnable> { }
}
