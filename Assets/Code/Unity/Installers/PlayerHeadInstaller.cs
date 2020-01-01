using Greed.Core;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Greed.Unity
{
	public class PlayerHeadInstaller : MonoInstaller
	{
		[SerializeField] private AssetReference _impactEffect;
		[SerializeField] private AudioClip _impactClip;

		public override void InstallBindings()
		{
			Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();

			Container.BindInterfacesAndSelfTo<ImpactHandler>().AsSingle()
				.WithArguments(_impactEffect, _impactClip);

			var impactColliderTag = "ImpactCollider";
			Container.BindInterfacesAndSelfTo<PickupHandler>().AsSingle()
				.WithArguments(impactColliderTag);
		}
	}
}
