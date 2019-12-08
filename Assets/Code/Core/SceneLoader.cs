using System;
using UniRx.Async;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Greed.Core
{
	public class SceneLoader
	{
		public async UniTask LoadScene(AssetReference sceneAsset)
		{
			var sceneInstance = await Addressables.LoadSceneAsync(sceneAsset, LoadSceneMode.Additive).Task;

			if (sceneInstance.Scene.isLoaded == false)
			{
				throw new Exception("Failed to load scene.");
			}
		}
	}
}
