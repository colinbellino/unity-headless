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
		private bool _lineStarted;
		private Vector3Int _startPosition;
		private LevelData _levelData;

		public Powered Powered { get; private set; }
		public PowerSource PowerSource { get; private set; }

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
				PowerSource = EndLine(tilemap, position);
				if (PowerSource)
				{
					_levelData.ConnectPower(_startPosition, position);
					// Debug.Log($"Connected power source: {Powered?.name}[{Powered?.GetInstanceID()}] -> {PowerSource.name}[{PowerSource.GetInstanceID()}]");
					ResetPower();
				}
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
				PowerSource = EndLine(tilemap, position);
				if (PowerSource)
				{
					_levelData.DisconnectPower(_startPosition, position);
					// Debug.Log($"Disconneted power source: {Powered?.name}[{Powered?.GetInstanceID()}] -> {PowerSource.name}[{PowerSource.GetInstanceID()}]");
					ResetPower();
				}
			}
		}

		private void ResetPower()
		{
			Powered = null;
			PowerSource = null;
		}

		private void StartLine(Tilemap tilemap, Vector3Int position)
		{
			ResetPower();

			var powered = tilemap.GetInstantiatedObject(position)?.GetComponent<Powered>();
			if (powered == null)
			{
				Debug.LogWarning("Selected tile can't be powered.");
				return;
			}

			InitializeLevelData();

			_startPosition = position;
			Powered = powered;
			_lineStarted = true;
		}

		private PowerSource EndLine(Tilemap tilemap, Vector3Int position)
		{
			var powerSource = tilemap.GetInstantiatedObject(position)?.GetComponent<PowerSource>();
			if (powerSource == null)
			{
				Debug.LogWarning("Selected tile isn't a power source.");
				return null;
			}

			_lineStarted = false;
			return powerSource;
		}

		private void InitializeLevelData()
		{
			if (_levelData != null)
			{
				return;
			}

			var levelData = FindObjectOfType<LevelData>();
			if (levelData == null)
			{
				Debug.LogError("Couldn't find LevelData in the scene.");
				return;
			}

			_levelData = levelData;
		}
	}

	/// <summary>
	/// The Brush Editor for a Power Brush.
	/// </summary>
	[CustomEditor(typeof(PowerBrush))]
	public class PowerBrushEditor : GridBrushEditor
	{
		private Tilemap _tilemap;

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

			if (_tilemap == null)
			{
				_tilemap = brushTarget.GetComponent<Tilemap>();
			}

			var powered = _tilemap.GetInstantiatedObject(position.position)?.GetComponent<Powered>();
			var powerSource = _tilemap.GetInstantiatedObject(position.position)?.GetComponent<PowerSource>();

			Handles.Label(grid.CellToWorld(position.position), GetLabel(brush as PowerBrush, powered, powerSource));
		}

		private string GetLabel(PowerBrush brush, Powered powered, PowerSource powerSource)
		{
			var label = "";

			if (powered)
			{
				label = $"{powered.name} {powered.transform.position - _tilemap.tileAnchor}";
			}
			else if (powerSource)
			{
				if (brush.Powered)
				{
					label = $"{brush.Powered.name} {brush.Powered.transform.position - _tilemap.tileAnchor} -> {powerSource.name} {powerSource.transform.position - _tilemap.tileAnchor}";
				}
				else
				{
					label = $"{powerSource.name} {powerSource.transform.position - _tilemap.tileAnchor}";
				}
			}

			return label;
		}
	}
}
