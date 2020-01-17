using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor.Tilemaps;
using Zenject;

namespace Greed.Unity.Editor
{
	[CustomGridBrush(true, false, false, "Door Brush")]
	public class DoorBrush : GridBrush
	{
		public override void Paint(GridLayout grid, GameObject brushTarget, Vector3Int position)
		{
			// Do not allow editing palettes
			if (brushTarget.layer == 31)
			{
				return;
			}

			var tilemap = brushTarget.GetComponent<Tilemap>();
			if (tilemap == null)
			{
				Debug.LogWarning("No tilemap selected.");
				return;
			}

			AddPowerSource(tilemap, position);
		}

		public override void Erase(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
		{
			// Do not allow editing palettes
			if (brushTarget.layer == 31)
			{
				return;
			}

			var tilemap = brushTarget.GetComponent<Tilemap>();
			if (tilemap == null)
			{
				Debug.LogWarning("No tilemap selected.");
				return;
			}

			RemovePowerSource(tilemap, position);
		}

		private static void AddPowerSource(Tilemap tilemap, Vector3Int position)
		{
			var tile = tilemap.GetTile<DoorTile>(position);
			if (tile == null)
			{
				return;
			}

			var powerSource = FindObjectOfType<PowerSource>();
			GetLevelInstaller().LevelData.AddPowerSource(position, powerSource);
		}

		private static void RemovePowerSource(Tilemap tilemap, Vector3Int position)
		{
			var tile = tilemap.GetTile<DoorTile>(position);
			if (tile == null)
			{
				return;
			}

			var powerSource = FindObjectOfType<PowerSource>();
			GetLevelInstaller().LevelData.RemovePowerSource(position, powerSource);
		}

		private static LevelInstaller GetLevelInstaller()
		{
			var sceneContext = GameObject.Find("Level Context").GetComponent<SceneContext>();
			foreach (var installer in sceneContext.Installers)
			{
				if (installer is LevelInstaller)
				{
					return installer as LevelInstaller;
				};
			}

			return null;
		}
	}
}
