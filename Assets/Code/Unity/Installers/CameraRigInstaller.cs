using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class CameraRigInstaller : MonoInstaller
	{
		[SerializeField] private Transform _rig;

		public override void InstallBindings()
		{
			// TODO: Remove me
			Container.Bind<AsyncProcessor>().FromNewComponentOnNewGameObject().AsSingle();

			Container.BindInterfacesAndSelfTo<CameraRig>().AsSingle()
				.WithArguments(_rig);
		}
	}
}
