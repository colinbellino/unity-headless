using System.Linq;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class LevelInstaller : MonoInstaller<LevelInstaller>
	{
		public LevelData LevelData;

		public override void InstallBindings()
		{
			// Container.Bind<LevelData>().AsSingle();
		}

		// TODO: Move this to another class
		public void OnDrawGizmos()
		{
			Gizmos.color = Color.red;

			foreach (var (position, data) in LevelData.PoweredDevicesMap.Select(x => (x.Key, x.Value)))
			{
				foreach (var powerSource in data.PowerSources)
				{
					if (powerSource)
					{
						Gizmos.DrawLine(GetCellCenter(position), powerSource.GetComponent<Transform>().position);
					}
				}
			}
		}

		private static Vector3 GetCellCenter(Vector3Int position)
		{
			return position + new Vector3(0.5f, 0.5f, 0);
		}
	}
}
