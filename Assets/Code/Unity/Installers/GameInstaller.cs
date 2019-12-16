using System.Collections.Generic;
using Greed.Core;
using Greed.UnityWrapper;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Greed.Unity
{
	public class GameInstaller : MonoInstaller
	{
		[Inject] private EntityFacade _playerPrefab;
		[Inject] private List<AssetReference> _loadedScenes;

		public override void InstallBindings()
		{
			// Use the CameraRig in the scene.
			Container.Bind<ICameraRig>().FromComponentInHierarchy().AsSingle();

			// Scene management.
			Container.Bind<ZenjectSceneLoaderAddressables>().AsSingle();
			Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();

			Container.BindInterfacesAndSelfTo<EffectsManager>().AsSingle();
			Container.Bind<ITime>().To<UnityTime>().AsSingle();
			Container.Bind<InteractiveObjectFinder>().AsSingle();
			Container.Bind<PlayerActions>().AsSingle();

			InstallFactories();

			// TODO: Enable this only in dev builds.
			Container.BindInterfacesTo<DebugMenuHandler>().AsSingle().NonLazy();

			// Load and bootstrap the game.
			Container.BindInterfacesTo<Bootstrap>().AsSingle()
				.WithArguments(Wrappers.Wrap(_playerPrefab.gameObject), _loadedScenes).NonLazy();

			InstallSignals();
		}

		private void InstallFactories()
		{
			Container.BindFactory<Object, IEntity, EntityFactory>().FromFactory<PrefabFactory<IEntity>>();
			Container.BindFactory<IState, StateFactory>().To<State>();
		}

		private void InstallSignals()
		{
			SignalBusInstaller.Install(Container);

			Container.DeclareSignal<TitleScreenLoadedSignal>();
			Container.DeclareSignal<GameStartedSignal>();
			Container.DeclareSignal<PickUpStartedSignal>();
			Container.DeclareSignal<PickUpEndedSignal>();
			Container.DeclareSignal<ThrowStartedSignal>();
			Container.DeclareSignal<ThrowEndedSignal>();
		}
	}
}
