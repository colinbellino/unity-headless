using System;
using Greed.UnityWrapper;
using UniRx.Async;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Greed.Core
{
	public class SceneLoader
	{
		public async UniTask LoadScene(AssetReference sceneAsset)
		{
			var scene = await Addressables.LoadSceneAsync(sceneAsset, LoadSceneMode.Additive).Task;
		}
	}
}
