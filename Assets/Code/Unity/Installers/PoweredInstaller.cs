using System.Collections.Generic;
using System.Linq;
using Greed.Core;
using Zenject;

namespace Greed.Unity
{
	public class PoweredInstaller : MonoInstaller
	{
		private List<PowerSource> _powerSources = new List<PowerSource>();

		public override void InstallBindings()
		{
			UnityEngine.Debug.Log("Installing powered device: " + string.Join(", ", _powerSources));

			Container.BindInstance(_powerSources.ToList<IPowerSource>()).WhenInjectedInto<Powered>();
		}
	}
}
