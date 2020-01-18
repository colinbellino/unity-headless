using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class LevelInstaller : MonoInstaller<LevelInstaller>
	{
		[SerializeField] [Required] private LevelData _levelData;

		public override void InstallBindings()
		{
			Container.BindInstance(_levelData).IfNotBound();
		}
	}
}
