using System.Collections.Generic;
using System.Linq;
using Greed.Core;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class PoweredInstaller : MonoInstaller
	{
		[Inject] private LevelData _levelData;

		private PowerSource[] _scenePowerSources;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<Powered>().FromComponentOnRoot();

			InstallPowerSources();
		}

		private void InstallPowerSources()
		{
			_scenePowerSources = FindObjectsOfType<PowerSource>();

			var powerSources = GetPowerSourcesFromLevelData();
			Container.BindInstance(powerSources).WhenInjectedInto<Powered>();
		}

		private List<IPowerSource> GetPowerSourcesFromLevelData()
		{
			var powerSources = new List<IPowerSource>();

			foreach (var (poweredPosition, data) in _levelData.PowerMap.Select(x => (x.Key, x.Value)))
			{
				if (transform.position == poweredPosition)
				{
					foreach (var powerSourcePosition in data.PowerSources)
					{
						var powerSource = GetPowerSourceAtPosition(poweredPosition);
						if (powerSource != null)
						{
							powerSources.Add(powerSource);
						}
					}
				}
			}

			return powerSources;
		}

		private IPowerSource GetPowerSourceAtPosition(Vector3Int position)
		{
			foreach (var powerSource in _scenePowerSources)
			{
				if (powerSource.transform.position == position)
				{
					return powerSource;
				}
			};

			return null;
		}
	}
}
