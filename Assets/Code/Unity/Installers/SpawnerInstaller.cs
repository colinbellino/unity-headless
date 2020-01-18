using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class SpawnerInstaller : MonoInstaller<SpawnerInstaller>
	{
		[SerializeField]
		[Required]
		[AssetsOnly]
		private GameObject _prefab;

		public override void InstallBindings()
		{
			Container.BindFactory<Spawnable, SpawnableFactory>().FromComponentInNewPrefab(_prefab);
		}
	}
}
