using Greed.Core;
using Greed.UnityWrapper;
using Zenject;

namespace Greed.Unity
{
	public class GameInstaller : MonoInstaller
	{
		[Inject] private CameraRigFacade _cameraRigPrefab;
		[Inject] private EntityFacade _playerPrefab;
		[Inject] private MainMenuFacade _mainMenuPrefab;

		public override void InstallBindings()
		{
			// Use the CameraRig in the scene, or default to prefab.
			Container.Bind<ICameraRig>().To<CameraRigFacade>().FromComponentInHierarchy().AsSingle();
			Container.Bind<ICameraRig>().FromComponentInNewPrefab(_cameraRigPrefab).AsSingle().IfNotBound();

			// Use the MainMenu in the scene, or default to prefab.
			Container.Bind<IMainMenu>().To<MainMenuFacade>().FromComponentInHierarchy().AsSingle();
			Container.Bind<IMainMenu>().FromComponentInNewPrefab(_mainMenuPrefab).AsSingle().IfNotBound();

			Container.Bind<IEntity>().FromComponentInNewPrefab(_playerPrefab).AsSingle();

			Container.Bind<PlayerActions>().AsSingle();
			Container.BindInterfacesTo<UnityTime>().AsSingle();
			Container.BindInterfacesTo<Bootstrap>().AsSingle();
		}
	}
}
