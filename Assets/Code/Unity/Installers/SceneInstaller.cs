using Greed.Core;
using Greed.UnityWrapper;
using Zenject;

public class SceneInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<ITime>().To<UnityTime>().AsSingle();
		InstallSignals();
	}

	private void InstallSignals()
	{
		SignalBusInstaller.Install(Container);

		Container.DeclareSignal<TitleScreenLoadedSignal>();
		Container.DeclareSignal<GameStartedSignal>();
		Container.DeclareSignal<PickUpStartedSignal>();
		Container.DeclareSignal<PickUpEndedSignal>();
	}
}
