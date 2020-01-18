using Zenject;

namespace Greed.Unity
{
	public class LevelInstaller : MonoInstaller<LevelInstaller>
	{
		public override void InstallBindings()
		{
			// FIXME: Inject power sources.
			// Container.Bind<LevelData>().AsSingle();
		}
	}
}
