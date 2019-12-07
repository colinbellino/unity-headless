using Greed.Core;
using Zenject;

namespace Greed.Unity
{
	public class TitleScreenInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesTo<TitleScreenHandler>().AsSingle();
		}
	}
}
