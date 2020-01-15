using System.Collections.Generic;
using System.Linq;
using Greed.Core;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class PoweredInstaller : MonoInstaller
	{
		// [SerializeField] private List<PowerSource> _powerSources;
		public List<PowerSource> _powerSources = new List<PowerSource>();

		public override void InstallBindings()
		{
			UnityEngine.Debug.Log("installing powered device: " + _powerSources.Count);
			Container.BindInterfacesAndSelfTo<Powered>().AsSingle()
				.WithArguments(_powerSources.ToList<IPowerSource>());
		}
	}
}
