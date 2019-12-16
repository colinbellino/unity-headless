using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Greed.Core
{
	public interface ISceneLoader
	{
		Task<Scene> LoadSceneAsync(AssetReference sceneAsset, LoadSceneMode loadMode = LoadSceneMode.Single);
	}
}
