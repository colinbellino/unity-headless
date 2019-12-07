using System;
using Greed.UnityWrapper;
using UniRx.Async;
using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class Bootstrap : IInitializable
	{
		private readonly SignalBus _signalBus;
		private readonly EntityFactory _entityFactory;
		private readonly IGameObject _playerPrefab;

		private readonly Vector3 _playerPosition = new Vector3(0f, -2f, 0f);

		public Bootstrap(SignalBus signalBus, EntityFactory entityFactory, IGameObject playerPrefab)
		{
			_signalBus = signalBus;
			_entityFactory = entityFactory;
			_playerPrefab = playerPrefab;
		}

		public async void Initialize()
		{
			await LoadAssets();
			await InitializeScene();
			ShowTitleScreen();
			await StartGame();
		}

		private UniTask LoadAssets()
		{
			// TODO: Show loader or something.
			return UniTask.Delay(TimeSpan.FromSeconds(1));
		}

		private async UniTask InitializeScene()
		{
			await UniTask.Delay(TimeSpan.FromSeconds(0));

			// FIXME: Disable all inputs when the game isn't started.
			// FIXME: Load level scene (additive).

			var player = _entityFactory.Create(_playerPrefab.Original);
			player.Place(_playerPosition);
		}

		private void ShowTitleScreen()
		{
			_signalBus.Fire(new TitleScreenLoadedSignal());
		}

		private async UniTask StartGame()
		{
			// TODO: Use player input instead of this delay.
			await UniTask.Delay(TimeSpan.FromSeconds(2));

			_signalBus.Fire(new GameStartedSignal());
		}
	}

	public class TitleScreenLoadedSignal { }
	public class GameStartedSignal { }
}
