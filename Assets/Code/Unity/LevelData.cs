using UnityEngine;
using System.Collections.Generic;
using System;
using Sirenix.OdinInspector;
using UnityEditor;

namespace Greed.Unity
{
	[CreateAssetMenu(menuName = "Greed/LevelData")]
	public class LevelData : SerializedScriptableObject
	{
		public PoweredDevicesMap PoweredDevicesMap = new PoweredDevicesMap();

		public void AddPowerSource(Vector3Int position, PowerSource powerSource)
		{
			var data = GetData(position);
			data.AddPowerSource(powerSource);
			PoweredDevicesMap[position] = data;

			Save();
		}

		public void RemovePowerSource(Vector3Int position, PowerSource powerSource)
		{
			var data = GetData(position);
			data.RemovePowerSource(powerSource);
			PoweredDevicesMap[position] = data;

			Save();
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

		private void Save()
		{
			EditorUtility.SetDirty(this);
			AssetDatabase.SaveAssets();
		}
	}

	[Serializable]
	public class PoweredDevicesMap : UnitySerializedDictionary<Vector3Int, PoweredDeviceData> { }

	[Serializable]
	public class PoweredDeviceData
	{
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
