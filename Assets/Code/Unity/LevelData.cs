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
		public PowerMap PowerMap;

		public void AddPowerSource(Vector3Int poweredPosition, Vector3Int sourcePosition)
		{
			var data = GetData(poweredPosition);
			data.AddPowerSource(sourcePosition);
			PowerMap[poweredPosition] = data;
		}

		public void RemovePowerSource(Vector3Int poweredPosition, Vector3Int sourcePosition)
		{
			var data = GetData(poweredPosition);
			data.RemovePowerSource(sourcePosition);
			PowerMap[poweredPosition] = data;
		}

		private PoweredDeviceData GetData(Vector3Int position)
		{
			var data = new PoweredDeviceData();

			if (PowerMap.ContainsKey(position))
			{
				PowerMap.TryGetValue(position, out data);
			}

			return data;
		}

		[Button]
		public void Clean()
		{
			foreach (var (position, data) in PowerMap.Select(x => (x.Key, x.Value)))
			{
				data.PowerSources = data.PowerSources.Where(powerSource => powerSource != null).Distinct().ToList();
			}
		}
	}

	[Serializable]
	public class PowerMap : UnitySerializedDictionary<Vector3Int, PoweredDeviceData> { }

	[Serializable]
	public class PoweredDeviceData
	{
		public List<Vector3Int> PowerSources;

		public void AddPowerSource(Vector3Int powerSource)
		{
			if (PowerSources == null)
			{
				PowerSources = new List<Vector3Int>();
			}

			if (PowerSources.Contains(powerSource))
			{
				return;
			}

			PowerSources.Add(powerSource);
		}

		public void RemovePowerSource(Vector3Int powerSource)
		{
			if (!PowerSources.Contains(powerSource))
			{
				return;
			}

			PowerSources.Remove(powerSource);
		}
	}
}
