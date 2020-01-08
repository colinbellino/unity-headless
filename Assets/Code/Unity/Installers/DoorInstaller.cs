using Greed.Core;
using Zenject;

namespace Greed.Unity
{
	public class DoorInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			// Container.Bind<IEntity>().To<EntityFacade>().FromComponentOnRoot().AsSingle();
		}
	}
}
