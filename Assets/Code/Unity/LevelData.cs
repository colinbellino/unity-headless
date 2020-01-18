using UnityEngine;
using System.Collections.Generic;
using System;
using Sirenix.OdinInspector;

namespace Greed.Unity
{
	public class LevelData : MonoBehaviour
	{
		public PowerMap PowerMap;

		public void ConnectPower(Vector3Int poweredPosition, Vector3Int sourcePosition)
		{
			var data = GetData(poweredPosition);
			data.AddPowerSource(sourcePosition);
			PowerMap[poweredPosition] = data;
		}

		public void DisconnectPower(Vector3Int poweredPosition, Vector3Int sourcePosition)
		{
			var data = GetData(poweredPosition);
			data.RemovePowerSource(sourcePosition);
			PowerMap[poweredPosition] = data;
		}

		private PoweredDeviceData GetData(Vector3Int position)
		{
			if (PowerMap.ContainsKey(position))
			{
				PowerMap.TryGetValue(position, out var data);
				return data;
			}

			return new PoweredDeviceData();
		}

		[Button]
		public void Clear()
		{
			PowerMap.Clear();
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
			if (PowerSources == null)
			{
				PowerSources = new List<Vector3Int>();
			}

			if (!PowerSources.Contains(powerSource))
			{
				return;
			}

			PowerSources.Remove(powerSource);
		}
	}
}
