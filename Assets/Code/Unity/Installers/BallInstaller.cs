using Greed.Core;
using UnityEngine;
using UnityEngine.VFX;
using Zenject;

namespace Greed.Unity
{
	public class BallInstaller : MonoInstaller
	{
		[SerializeField] private VisualEffect _impactEffect;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<ImpactHandler>().AsSingle()
				.WithArguments(_impactEffect);
			Container.BindInterfacesAndSelfTo<PickupHandler>().AsSingle();

		}
	}
}
