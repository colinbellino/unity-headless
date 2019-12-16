using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Greed.Core
{
	public class SceneLoader : ISceneLoader
	{
		public async Task<Scene> LoadSceneAsync(AssetReference sceneAsset, LoadSceneMode loadMode = LoadSceneMode.Single)
		{
			var sceneInstance = await Addressables.LoadSceneAsync(sceneAsset, loadMode).Task;
			if (sceneInstance.Scene.isLoaded == false)
			{
				throw new Exception("Failed to load scene.");
			}

			Debug.Log("Loaded scene: " + sceneInstance.Scene.name);

			return sceneInstance.Scene;
		}
	}
}
