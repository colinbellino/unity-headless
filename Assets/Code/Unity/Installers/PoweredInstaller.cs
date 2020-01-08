using System.Collections.Generic;
using System.Linq;
using Greed.Core;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class PoweredInstaller : MonoInstaller
	{
		[SerializeField] private List<PowerSource> _powerSources;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<Powered>().AsSingle()
				.WithArguments(_powerSources.ToList<IPowerSource>());
		}
	}
}
