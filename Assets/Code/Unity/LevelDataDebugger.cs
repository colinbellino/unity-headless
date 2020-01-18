using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;

namespace Greed.Unity
{
	public class LevelDataDebugger : MonoBehaviour
	{
		[SerializeField] private LevelData _levelData;

		[Button]
		public void Clear()
		{
			_levelData.PowerMap.Clear();
		}

		public void OnDrawGizmos()
		{
			DrawPowerLines(Color.red);
		}

		private void DrawPowerLines(Color color)
		{
			foreach (var (poweredPosition, data) in _levelData.PowerMap.Select(x => (x.Key, x.Value)))
			{
				foreach (var powerSourcePosition in data.PowerSources)
				{
					Gizmos.color = color;
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
