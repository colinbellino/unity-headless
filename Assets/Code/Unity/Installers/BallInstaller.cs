using Greed.Core;
using Zenject;

namespace Greed.Unity
{
	public class BallInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesTo<PickUpHandler>().AsSingle();
		}
	}
}
