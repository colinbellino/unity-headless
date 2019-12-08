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
			try
			{
				var sceneInstance = await Addressables.LoadSceneAsync(sceneAsset, LoadSceneMode.Additive).Task;
				UnityEngine.Debug.Log("Scene loaded: " + sceneInstance.Scene.name);
			}
			catch (Exception e)
			{
				UnityEngine.Debug.LogError(e);
			}
		}
	}
}
