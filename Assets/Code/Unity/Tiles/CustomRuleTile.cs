using System;
using System.Collections.Generic;
using System.Linq;
using Greed.Core;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Greed.Unity
{
	[CreateAssetMenu(fileName = "New Custom Rule Tile", menuName = "Tiles/Custom Rule Tile")]
	public class CustomRuleTile : RuleTile
	{
		private PoweredInstaller _poweredInstaller;
		private GameObject bla;
		private List<PowerSource> _powerSources => GetCachedPoweredInstaller().bla;

		private PoweredInstaller GetCachedPoweredInstaller()
		{
			if (_poweredInstaller == null)
			{
				_poweredInstaller = bla.GetComponent<PoweredInstaller>();
			}

			return _poweredInstaller;
		}

		// TODO: Store this in another class maybe instead of inside the tiles?
		public void AddPowerSource(PowerSource powerSource)
		{
			UnityEngine.Debug.Log("AddPowerSource " + bla?.name);
			// if (_powerSources.Contains(powerSource))
			// {
			// 	Debug.LogWarning("Power source already connected: " + powerSource.name, _gameObject);
			// 	return;
			// }

			// _powerSources.Add(powerSource);
			// Debug.Log("Power source connected: " + powerSource.name, _gameObject);
		}

		public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		{
			base.GetTileData(position, tilemap, ref tileData);
			// UnityEngine.Debug.Log("GetTileData " + tileData.gameObject?.name);

			// UnityEngine.Debug.Log("GetTileData", _gameObject);
		}

		public override bool StartUp(Vector3Int location, ITilemap tilemap, GameObject instantiatedGameObject)
		{
			base.StartUp(location, tilemap, instantiatedGameObject);

			if (instantiatedGameObject)
			{
				instantiatedGameObject.name = RandomString(10);
				bla = instantiatedGameObject;
			}
			// UnityEngine.Debug.Log("StartUp " + instantiatedGameObject?.name);

			return true;
		}

		private static System.Random random = new System.Random();
		public static string RandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[random.Next(s.Length)]).ToArray());
		}
	}
}
