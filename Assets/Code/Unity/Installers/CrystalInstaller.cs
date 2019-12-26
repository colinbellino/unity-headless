using Greed.Core;
using Greed.UnityWrapper;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class CrystalInstaller : MonoInstaller
	{
		[SerializeField] private AudioClip _breakClip;
		[SerializeField] private Collider2D _impactCollider;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<BreaksOnImpactHandler>().AsSingle()
				.WithArguments(_breakClip, Wrappers.Wrap(_impactCollider));
		}
	}
}
