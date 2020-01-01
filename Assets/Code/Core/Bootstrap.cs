using System;
using System.Collections.Generic;
using Greed.UnityWrapper;
using UniRx.Async;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using Zenject;

namespace Greed.Core
{
	public class Bootstrap : IInitializable
	{
		private readonly SignalBus _signalBus;
		private readonly EntityFactory _entityFactory;
		private readonly ISceneLoader _sceneLoader;
		private readonly IGameObject _playerPrefab;
		private readonly List<AssetReference> _scenesToLoad;

		private readonly Vector3 _playerPosition = new Vector3(0f, -2f, 0f);

		public Bootstrap(
			SignalBus signalBus,
			EntityFactory entityFactory,
			ISceneLoader sceneLoader,
			IGameObject playerPrefab,
			List<AssetReference> scenesToLoad
		)
		{
			_signalBus = signalBus;
			_entityFactory = entityFactory;
			_sceneLoader = sceneLoader;
			_playerPrefab = playerPrefab;
			_scenesToLoad = scenesToLoad;
		}

		public async void Initialize()
		{
			try
			{
				await LoadAssets();
				await InitializeScene();
				ShowTitleScreen();
			}
			catch (Exception e)
			{
				// TODO: Find a better way to handle this?
				Debug.LogError("Couldn't initialize game: " + e);
			}
		}

		private UniTask LoadAssets()
		{
			// TODO: Show loader or something.
			return UniTask.Delay(TimeSpan.FromSeconds(0));
		}

		private async UniTask InitializeScene()
		{
			var levelUnloaded = SceneManager.sceneCount == 1;
			if (levelUnloaded)
			{
				await _sceneLoader.LoadSceneAsync(_scenesToLoad[0], LoadSceneMode.Additive);
			}

			// var existingPlayer = GameObject.Find("Player");
			// if (existingPlayer == null)
			// {
			// 	var player = _entityFactory.Create(_playerPrefab.Original);
			// 	player.View.Place(_playerPosition);
			// }
		}

		private void ShowTitleScreen()
		{
			_signalBus.Fire(new TitleScreenLoadedSignal());
		}
	}

	public class TitleScreenLoadedSignal { }

	public class GameStartedSignal { }
}
