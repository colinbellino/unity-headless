using System;
using UniRx.Async;
using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class Bootstrap : IInitializable
	{
		private readonly SignalBus _signalBus;
		private readonly PlayerFactory _playerFactory;

		private readonly Vector3 _playerPosition = new Vector3(0f, -2f, 0f);

		public Bootstrap(SignalBus signalBus, PlayerFactory playerFactory)
		{
			_signalBus = signalBus;
			_playerFactory = playerFactory;
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
			await UniTask.Delay(TimeSpan.FromSeconds(1));

			// TODO: Position the player.
			// FIXME: Disable all inputs when the game isn't started.
			_playerFactory.Create();
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
