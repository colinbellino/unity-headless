using Greed.Core;
using Zenject;

namespace Greed.Unity
{
	public class GameInstaller : MonoInstaller
	{
		[Inject] private CameraRigFacade _cameraRig;

		public override void InstallBindings()
		{
			Container.Bind<ICameraRig>().FromComponentInNewPrefab(_cameraRig).AsSingle();

			Container.BindInterfacesTo<Bootstrap>().AsSingle();
		}
	}
}
