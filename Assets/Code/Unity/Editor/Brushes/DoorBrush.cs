using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor.Tilemaps;
using Greed.Core;

namespace Greed.Unity.Editor
{
	[CustomGridBrush(true, false, false, "Door Brush")]
	// TODO: Rename to PowerBrush
	public class DoorBrush : GridBrush
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
				_levelData.AddPowerSource(_startPosition, _powerSource);
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
				_levelData.RemovePowerSource(_startPosition, _powerSource);
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
			// TODO: Use interface IPowerSource
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
}
