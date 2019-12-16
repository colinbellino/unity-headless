using System;
using System.Threading.Tasks;
using ModestTree;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using Zenject;

namespace Greed.Core
{
	public class ZenjectSceneLoaderAddressables : ISceneLoader
	{
		private readonly ProjectKernel _projectKernel;
		private readonly DiContainer _sceneContainer;

		public ZenjectSceneLoaderAddressables(
			[InjectOptional] SceneContext sceneRoot,
			ProjectKernel projectKernel)
		{
			_projectKernel = projectKernel;
			_sceneContainer = sceneRoot?.Container;
		}

		public void LoadScene(
			string sceneName,
			LoadSceneMode loadMode = LoadSceneMode.Single,
			Action<DiContainer> extraBindings = null,
			LoadSceneRelationship containerMode = LoadSceneRelationship.None,
			Action<DiContainer> extraBindingsLate = null
		)
		{
			PrepareForLoadScene(loadMode, extraBindings, extraBindingsLate, containerMode);

			Assert.That(Application.CanStreamedLevelBeLoaded(sceneName),
				"Unable to load scene '{0}'", sceneName);

			SceneManager.LoadScene(sceneName, loadMode);

			// It would be nice here to actually verify that the new scene has a SceneContext
			// if we have extra binding hooks, or LoadSceneRelationship != None, but
			// we can't do that in this case since the scene isn't loaded until the next frame
		}

		public Task<Scene> LoadSceneAsync(
			AssetReference sceneAsset,
			LoadSceneMode loadMode = LoadSceneMode.Single)
		{
			return LoadSceneAsync(sceneAsset, loadMode, null, LoadSceneRelationship.None, null);
		}

		private async Task<Scene> LoadSceneAsync(
			AssetReference sceneAsset,
			LoadSceneMode loadMode = LoadSceneMode.Single,
			Action<DiContainer> extraBindings = null,
			LoadSceneRelationship containerMode = LoadSceneRelationship.None,
			Action<DiContainer> extraBindingsLate = null)
		{
			PrepareForLoadScene(loadMode, extraBindings, extraBindingsLate, containerMode);

			var sceneInstance = await Addressables.LoadSceneAsync(sceneAsset, loadMode).Task;
			if (sceneInstance.Scene.isLoaded == false)
			{
				throw new Exception("Failed to load scene.");
			}

			return sceneInstance.Scene;
		}

		private void PrepareForLoadScene(
			LoadSceneMode loadMode,
			Action<DiContainer> extraBindings,
			Action<DiContainer> extraBindingsLate,
			LoadSceneRelationship containerMode)
		{
			if (loadMode == LoadSceneMode.Single)
			{
				Assert.IsEqual(containerMode, LoadSceneRelationship.None);

				// Here we explicitly unload all existing scenes rather than relying on Unity to
				// do this for us.  The reason we do this is to ensure a deterministic destruction
				// order for everything in the scene and in the container.
				// See comment at ProjectKernel.OnApplicationQuit for more details
				_projectKernel.ForceUnloadAllScenes();
			}

			if (containerMode == LoadSceneRelationship.None)
			{
				SceneContext.ParentContainers = null;
			}
			else if (containerMode == LoadSceneRelationship.Child)
			{
				if (_sceneContainer == null)
				{
					SceneContext.ParentContainers = null;
				}
				else
				{
					SceneContext.ParentContainers = new [] { _sceneContainer };
				}
			}
			else
			{
				Assert.IsNotNull(_sceneContainer,
					"Cannot use LoadSceneRelationship.Sibling when loading scenes from ProjectContext");
				Assert.IsEqual(containerMode, LoadSceneRelationship.Sibling);
				SceneContext.ParentContainers = _sceneContainer.ParentContainers;
			}

			SceneContext.ExtraBindingsInstallMethod = extraBindings;
			SceneContext.ExtraBindingsLateInstallMethod = extraBindingsLate;
		}
	}
}
