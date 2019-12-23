using Greed.Core;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class CrystalInstaller : MonoInstaller
	{
		[SerializeField] private AudioClip _breakClip;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<BreaksOnImpactHandler>().AsSingle()
				.WithArguments(_breakClip);
		}
	}
}
