using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class LevelInstaller : MonoInstaller<LevelInstaller>
	{
		public LevelData LevelData;

		public override void InstallBindings()
		{
			// Container.Bind<LevelData>().AsSingle();
		}
	}
}
