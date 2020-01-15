using System.Collections.Generic;
using System.Linq;
using Greed.Core;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class PoweredInstaller : MonoInstaller
	{
		public List<PowerSource> bla = new List<PowerSource>();

		public override void InstallBindings()
		{
			UnityEngine.Debug.Log("Installing powered device: " + string.Join(", ", bla));
			Container.BindInterfacesAndSelfTo<Powered>().AsSingle()
				.WithArguments(bla.ToList<IPowerSource>());
		}
	}
}
