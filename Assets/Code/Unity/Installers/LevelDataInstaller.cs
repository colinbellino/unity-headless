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
			var data = new PoweredDeviceData();
			data.AddPowerSource(powerSource);
			PoweredDevicesMap.Add(position, data);
			UnityEngine.Debug.Log("AddPowerSource " + position + " => " + powerSource);
		}

		public void RemovePowerSource(Vector3Int position, PowerSource powerSource)
		{
			UnityEngine.Debug.Log("RemovePowerSource " + position + " => " + powerSource);
		}
	}

	[Serializable]
	public class PoweredDevicesMap : UnitySerializedDictionary<Vector3Int, PoweredDeviceData> { }

	[Serializable]
	public class PoweredDeviceData
	{
		public readonly List<PowerSource> PowerSources = new List<PowerSource>();

		public void AddPowerSource(PowerSource powerSource)
		{
			PowerSources.Add(powerSource);
		}
	}
}
