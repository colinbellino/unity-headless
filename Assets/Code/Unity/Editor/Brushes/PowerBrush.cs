using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor.Tilemaps;
using Greed.Core;
using UnityEditor;

namespace Greed.Unity.Editor
{
	[CustomGridBrush(true, false, false, "Power Brush")]
	public class PowerBrush : GridBrush
	{
		private Powered _powered;
		private PowerSource _powerSource;
		private bool _lineStarted;
		private Vector3Int _startPosition;
		private LevelData _levelData;

		public override void Paint(GridLayout grid, GameObject brushTarget, Vector3Int position)
		{
			// Do not allow editing palettes
			if (brushTarget.layer == 31) { return; }

			var tilemap = brushTarget.GetComponent<Tilemap>();
			if (tilemap == null)
			{
				Debug.LogWarning("No tilemap selected.");
				return;
			}

			if (_lineStarted == false)
			{
				StartLine(tilemap, position);
			}
			else
			{
				EndLine(tilemap, position);
				_levelData.AddPowerSource(_startPosition, position);
				Debug.Log($"Connected power source: {_powered.name}[{_powered.GetInstanceID()}] -> {_powerSource.name}[{_powerSource.GetInstanceID()}]");
			}
		}

		public override void Erase(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
		{
			// Do not allow editing palettes
			if (brushTarget.layer == 31) { return; }

			var tilemap = brushTarget.GetComponent<Tilemap>();
			if (tilemap == null)
			{
				Debug.LogWarning("No tilemap selected.");
				return;
			}

			if (_lineStarted == false)
			{
				StartLine(tilemap, position);
			}
			else
			{
				EndLine(tilemap, position);
				_levelData.RemovePowerSource(_startPosition, position);
				Debug.Log($"Disconneted power source: {_powered.name}[{_powered.GetInstanceID()}] -> {_powerSource.name}[{_powerSource.GetInstanceID()}]");
			}
		}

		private void StartLine(Tilemap tilemap, Vector3Int position)
		{
			_powered = null;
			_powerSource = null;

			var powered = tilemap.GetInstantiatedObject(position)?.GetComponent<Powered>();
			if (powered == null)
			{
				Debug.LogWarning("Selected tile can't be powered.");
				return;
			}

			InitializeLevelData();

			_startPosition = position;
			_powered = powered;
			_lineStarted = true;
		}

		private void EndLine(Tilemap tilemap, Vector3Int position)
		{
			var powerSource = tilemap.GetInstantiatedObject(position)?.GetComponent<PowerSource>();
			if (powerSource == null)
			{
				Debug.LogWarning("Selected tile isn't a power source.");
				return;
			}

			_powerSource = powerSource;
			_lineStarted = false;
		}

		private void InitializeLevelData()
		{
			if (_levelData != null)
			{
				return;
			}

			var levelInstaller = FindObjectOfType<LevelInstaller>();
			if (levelInstaller == null)
			{
				Debug.LogError("Couldn't find LevelData in the scene.");
				return;
			}

			_levelData = levelInstaller.LevelData;
		}
	}

	/// <summary>
	/// The Brush Editor for a Power Brush.
	/// </summary>
	[CustomEditor(typeof(PowerBrush))]
	public class PowerBrushEditor : GridBrushEditor
	{
		/// <summary>
		/// Callback for painting the GUI for the GridBrush in the Scene View.
		/// The PowerBrush Editor overrides this to draw the current coordinates of the brush.
		/// </summary>
		/// <param name="gridLayout">Grid that the brush is being used on.</param>
		/// <param name="brushTarget">Target of the GridBrushBase::ref::Tool operation. By default the currently selected GameObject.</param>
		/// <param name="position">Current selected location of the brush.</param>
		/// <param name="tool">Current GridBrushBase::ref::Tool selected.</param>
		/// <param name="executing">Whether brush is being used.</param>
		public override void OnPaintSceneGUI(GridLayout grid, GameObject brushTarget, BoundsInt position, GridBrushBase.Tool tool, bool executing)
		{
			base.OnPaintSceneGUI(grid, brushTarget, position, tool, executing);

			var labelText = "Pos: " + position.position;
			if (position.size.x > 1 || position.size.y > 1)
			{
				labelText += " Size: " + position.size;
			}

			Handles.Label(grid.CellToWorld(position.position), labelText);
		}
	}
}
