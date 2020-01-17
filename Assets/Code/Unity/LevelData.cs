using UnityEngine;
using System.Collections.Generic;
using System;
using Sirenix.OdinInspector;
using System.Linq;

namespace Greed.Unity
{
	[Serializable]
	public class LevelData
	{
		public PoweredDevicesMap PoweredDevicesMap = new PoweredDevicesMap();

		// FIXME: tile's instanciated objects are recreated when the tilemap refreshes so we need to use positions only
		public void AddPowerSource(Vector3Int position, PowerSource powerSource)
		{
			var data = GetData(position);
			data.AddPowerSource(powerSource);
			PoweredDevicesMap[position] = data;
		}

		public void RemovePowerSource(Vector3Int position, PowerSource powerSource)
		{
			var data = GetData(position);
			data.RemovePowerSource(powerSource);
			PoweredDevicesMap[position] = data;
		}

		private PoweredDeviceData GetData(Vector3Int position)
		{
			var data = new PoweredDeviceData();

			if (PoweredDevicesMap.ContainsKey(position))
			{
				PoweredDevicesMap.TryGetValue(position, out data);
			}

			return data;
		}

		[Button]
		public void Clean()
		{
			foreach (var (position, data) in PoweredDevicesMap.Select(x => (x.Key, x.Value)))
			{
				data.PowerSources = data.PowerSources.Where(powerSource => powerSource != null).Distinct().ToList();
			}
		}
	}

	[Serializable]
	public class PoweredDevicesMap : UnitySerializedDictionary<Vector3Int, PoweredDeviceData> { }

	[Serializable]
	public class PoweredDeviceData
	{
		// TODO: Store coordinates only?
		public List<PowerSource> PowerSources = new List<PowerSource>();

		public void AddPowerSource(PowerSource powerSource)
		{
			if (PowerSources.Contains(powerSource))
			{
				return;
			}

			PowerSources.Add(powerSource);
		}

		public void RemovePowerSource(PowerSource powerSource)
		{
			if (!PowerSources.Contains(powerSource))
			{
				return;
			}

			PowerSources.Remove(powerSource);
		}
	}
}
