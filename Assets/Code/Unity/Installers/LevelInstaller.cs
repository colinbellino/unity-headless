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
			// FIXME: Inject power sources.
			// Container.Bind<LevelData>().AsSingle();
		}

		// TODO: Move this to a new LevelDataVisualiser class.
		public void OnDrawGizmos()
		{
			Gizmos.color = Color.red;

			foreach (var (poweredPosition, data) in LevelData.PowerMap.Select(x => (x.Key, x.Value)))
			{
				foreach (var powerSourcePosition in data.PowerSources)
				{
					Gizmos.DrawLine(GetCellCenter(poweredPosition), GetCellCenter(powerSourcePosition));
				}
			}
		}

		private static Vector3 GetCellCenter(Vector3Int position)
		{
			return position + new Vector3(0.5f, 0.5f, 0);
		}
	}
}
