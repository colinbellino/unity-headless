using Greed.Core;
using UnityEngine;
using UnityEngine.VFX;
using Zenject;

namespace Greed.Unity
{
	public class BallInstaller : MonoInstaller
	{
		[SerializeField] private VisualEffect _impactEffect;
		[SerializeField] private AudioClip _impactClip;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<ImpactHandler>().AsSingle()
				.WithArguments(_impactEffect, _impactClip);
			Container.BindInterfacesAndSelfTo<PickupHandler>().AsSingle();

		}
	}
}
