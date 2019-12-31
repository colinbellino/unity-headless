using Greed.Core;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class CameraRigInstaller : MonoInstaller
	{
		[SerializeField] private Transform _rig;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<CameraRig>().AsSingle()
				.WithArguments(_rig);
		}
	}
}
