using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Greed.Core
{
	public class VisualEffectsSpawner
	{
		// FIXME: Don't spawn load/instantiate every time this is called, load assets beforehand and cache/poll stuff.
		public async void Create(AssetReference asset, Vector3 position, Quaternion rotation)
		{
			await asset.InstantiateAsync(position, rotation, null).Task;
		}
	}
}
