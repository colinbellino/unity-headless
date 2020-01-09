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

		[SerializeField] private EntityFacade _playerHead;
		[SerializeField] private EntityFacade _playerBody;

		public override void InstallBindings()
		{
			Container.Bind<AsyncProcessor>().FromNewComponentOnNewGameObject().AsSingle();

			// Use the CameraRig in the scene.
			Container.Bind<ICameraRig>().FromComponentInHierarchy().AsSingle();

			// Scene management.
			Container.Bind<ZenjectSceneLoaderAddressables>().AsSingle();
			Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();

			Container.BindInterfacesAndSelfTo<VisualEffectsSpawner>().AsSingle();
			Container.Bind<ITime>().To<UnityTime>().AsSingle();
			Container.Bind<InteractiveObjectFinder>().AsSingle();

			InstallFactories();
			InstallSignals();
			InstallPlayer();

			// TODO: Enable this only in dev builds.
			Container.BindInterfacesTo<DebugMenuHandler>().AsSingle().NonLazy();

			// Load and bootstrap the game.
			Container.BindInterfacesTo<Bootstrap>().AsSingle()
				.WithArguments(Wrappers.Wrap(_playerPrefab.gameObject), _loadedScenes).NonLazy();
		}

		private void InstallPlayer()
		{
			Container.Bind<IPlayer>().To<PlayerFacade>().AsSingle()
				.WithArguments(_playerHead, _playerBody);

			Container.Bind<PlayerActions>().AsSingle();
			Container.Bind<EntityInputState>().AsSingle();
			Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
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
			Container.DeclareSignal<ImpactHitSignal>().OptionalSubscriber();
			Container.DeclareSignal<CollectedSignal>();
			Container.DeclareSignal<FellSignal>().OptionalSubscriber();
			Container.DeclareSignal<ButtonActivatedSignal>();
			Container.DeclareSignal<PowerSourceToggledSignal>();

			Container.DeclareSignal<PlayerInputsEnabledSignal>();
			Container.DeclareSignal<PlayerInputsDisabledSignal>();
			Container.DeclareSignal<PlayerHeadRecalledSignal>();
			Container.DeclareSignal<PlayerHeadThrownSignal>();
		}
	}
}
