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

		private Dictionary<Vector3Int, PowerSource> _scenePowerSources = new Dictionary<Vector3Int, PowerSource>();

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<Powered>().FromComponentOnRoot();

			InstallPowerSources();
		}

		private void InstallPowerSources()
		{
			foreach (var powerSource in FindObjectsOfType<PowerSource>())
			{
				_scenePowerSources.Add(_levelData.Grid.WorldToCell(powerSource.transform.position), powerSource);
			}

			var powerSources = GetPowerSourcesFromLevelData();
			Container.BindInstance(powerSources).WhenInjectedInto<Powered>();
		}

		private List<IPowerSource> GetPowerSourcesFromLevelData()
		{
			var powerSources = new List<IPowerSource>();
			var poweredPosition = _levelData.Grid.WorldToCell(transform.position);

			foreach (var (currentPosition, data) in _levelData.PowerMap.Select(x => (x.Key, x.Value)))
			{
				if (currentPosition != poweredPosition)
				{
					continue;
				}

				foreach (var powerSourcePosition in data.PowerSources)
				{
					_scenePowerSources.TryGetValue(powerSourcePosition, out var powerSource);
					if (powerSource != null)
					{
						powerSources.Add(powerSource);
					}
				}
			}

			return powerSources;
		}
	}
}
