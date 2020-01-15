using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Greed.Unity
{
	[CustomGridBrush(true, false, false, "Custom Brush")]
	[CreateAssetMenu(fileName = "New Custom Brush", menuName = "Brushes/Custom Brush")]
	public class CustomBrush : UnityEditor.Tilemaps.GridBrush
	{
		public override void Paint(GridLayout grid, GameObject brushTarget, Vector3Int position)
		{
			// Do not allow editing palettes
			if (brushTarget.layer == 31)
			{
				return;
			}

			var tilemap = brushTarget.GetComponent<Tilemap>();
			if (tilemap != null)
			{
				AddPowerSource(tilemap, position);
			}
		}

		private void AddPowerSource(Tilemap tilemap, Vector3Int position)
		{
			var tile = tilemap.GetTile<CustomRuleTile>(position);
			if (tile == null)
			{
				return;
			}

			var powerSource = FindObjectOfType<PowerSource>();
			tile.AddPowerSource(powerSource);
		}
	}

	[CustomEditor(typeof(CustomBrush))]
	public class CustomBrushEditor : UnityEditor.Tilemaps.GridBrushEditor
	{
		public override void OnPaintSceneGUI(GridLayout grid, GameObject brushTarget, BoundsInt position, GridBrushBase.Tool tool, bool executing)
		{
			base.OnPaintSceneGUI(grid, brushTarget, position, tool, executing);

			// UnityEngine.Debug.Log($"position: {position.position} [ size: {position.size}");

			// Handles.Label(grid.CellToWorld(position.position), labelText);
		}
	}
}
