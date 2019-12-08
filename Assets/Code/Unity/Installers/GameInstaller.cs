using System.Collections.Generic;
using System.Linq;
using Greed.Core;
using Greed.UnityWrapper;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using Zenject;

namespace Greed.Unity
{
	public class GameInstaller : MonoInstaller
	{
		// [Inject] private CameraRigFacade _cameraRigPrefab;
		[Inject] private EntityFacade _playerPrefab;
		[Inject] private List<AssetReference> _loadedScenes;

		public override void InstallBindings()
		{
			// Use the CameraRig in the scene, or default to the injected prefab.
			Container.Bind<ICameraRig>().FromComponentInHierarchy().When(ExistsInScene);
			// Container.Bind<ICameraRig>().FromComponentInNewPrefab(_cameraRigPrefab).AsSingle().IfNotBound();

			Container.Bind<ITime>().To<UnityTime>().AsSingle();

			InstallFactories();
			InstallSignals();

			// TODO: Enable this only in dev builds
			Container.BindInterfacesTo<DebugMenuHandler>().AsSingle().NonLazy();

			// Bootstrap the game
			Container.Bind<PlayerActions>().AsSingle();
			Container.Bind<SceneLoader>().AsSingle();
			// Container.BindInterfacesTo<TitleScreenHandler>().AsSingle().NonLazy();
			Container.BindInterfacesTo<Bootstrap>().AsSingle()
				.WithArguments(Wrappers.Wrap(_playerPrefab.gameObject), _loadedScenes).NonLazy();
		}

		private void InstallFactories()
		{
			Container.BindFactory<Object, IEntity, EntityFactory>().FromFactory<PrefabFactory<IEntity>>();
		}

		private void InstallSignals()
		{
			SignalBusInstaller.Install(Container);

			Container.DeclareSignal<TitleScreenLoadedSignal>();
			Container.DeclareSignal<GameStartedSignal>();
		}

		private bool ExistsInScene(InjectContext context)
		{
			return SceneManager.GetActiveScene().GetRootGameObjects()
				.Select(x => x.GetComponentInChildren(context.MemberType, false))
				.Where(x => x != null && !ReferenceEquals(x, context.ObjectInstance))
				.FirstOrDefault();
		}
	}
}
