using System.Collections.Generic;
using Greed.Core;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Greed.Unity
{
	[CreateAssetMenu(fileName = "New Custom Rule Tile", menuName = "Tiles/Custom Rule Tile")]
	public class CustomRuleTile : Tile
	{
		// private readonly List<PowerSource> _powerSources = new List<PowerSource>();
		private List<PowerSource> PowerSources => gameObject.GetComponent<PoweredInstaller>()._powerSources;

		public void AddPowerSource(PowerSource powerSource)
		{
			if (PowerSources.Contains(powerSource))
			{
				return;
			}

			PowerSources.Add(powerSource);
			UnityEngine.Debug.Log(PowerSources.Count);
		}

		// public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		// {
		//     tileData.gameObject = m_InstancedGameObject;
		// }

		// public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
		// {
		// 	UnityEngine.Debug.Log("start up " + _powerSources.Count);
		// 	return true;
		// }

		// public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		// {
		// 	base.GetTileData(position, tilemap, ref tileData);

		// 	var powered = tileData.gameObject.GetComponent<PoweredInstaller>();
		// 	powered._powerSources = _powerSources;
		// 	// UnityEngine.Debug.Log(tileData.gameObject.transform.root.hideFlags);
		// 	// tileData.gameObject.transform.root.hideFlags = HideFlags.None;

		// 	UnityEngine.Debug.Log("GetTileData " + powered._powerSources.Count);
		// 	// UnityEngine.Debug.Log("gettiledata " + _powerSources.Count);
		// }
	}
}
