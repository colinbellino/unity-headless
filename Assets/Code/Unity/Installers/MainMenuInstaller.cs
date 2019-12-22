using Greed.Core;
using Zenject;

namespace Greed.Unity
{
	public class MainMenuInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesTo<TitleScreenHandler>().AsSingle();
		}
	}
}
