using Greed.Core;
using Greed.UnityWrapper;
using Zenject;

namespace Greed.Unity
{
	public class GameInstaller : MonoInstaller
	{
		[Inject] private CameraRigFacade _cameraRigPrefab;
		[Inject] private EntityFacade _playerPrefab;

		public override void InstallBindings()
		{
			Container.Bind<ICameraRig>().FromComponentInNewPrefab(_cameraRigPrefab).AsSingle();
			Container.Bind<IEntity>().FromComponentInNewPrefab(_playerPrefab).AsSingle();

			Container.Bind<PlayerActions>().AsSingle();
			Container.BindInterfacesTo<UnityTime>().AsSingle();
			Container.BindInterfacesTo<Bootstrap>().AsSingle();
		}
	}
}
