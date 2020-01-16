using UnityEngine;
using Zenject;
using System.Collections.Generic;
using System;

namespace Greed.Unity
{
	[CreateAssetMenu(fileName = "LevelDataInstaller", menuName = "Installers/LevelDataInstaller")]
	public class LevelDataInstaller : ScriptableObjectInstaller<LevelDataInstaller>
	{
		public LevelData LevelData;

		public override void InstallBindings()
		{
			// Container.Bind<LevelData>().AsSingle();
		}
	}

	[Serializable]
	public class LevelData
	{
		public PoweredDevicesMap PoweredDevicesMap = new PoweredDevicesMap();

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
