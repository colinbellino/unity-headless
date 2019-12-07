using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Greed.Core
{
	public class TitleScreenHandler : IInitializable, IDisposable
	{
		private readonly SignalBus _signalBus;
		private readonly IPanelView _view;
		private readonly PlayerActions _actions;

		public TitleScreenHandler(SignalBus signalBus, IPanelView view, PlayerActions actions)
		{
			_signalBus = signalBus;
			_view = view;
			_actions = actions;
		}

		public void Initialize()
		{
			_view.Hide();

			_signalBus.Subscribe<TitleScreenLoadedSignal>(OnTitleScreenLoaded);
			_signalBus.Subscribe<GameStartedSignal>(OnGameStartedSignal);
		}

		public void Dispose()
		{
			_signalBus.Unsubscribe<TitleScreenLoadedSignal>(OnTitleScreenLoaded);
			_signalBus.Unsubscribe<GameStartedSignal>(OnGameStartedSignal);
		}

		private void OnTitleScreenLoaded()
		{
			_actions.TitleScreen.Enable();
			_actions.TitleScreen.Start.performed += OnStartPerformed;
			_view.Show();
		}

		private void OnGameStartedSignal()
		{
			_actions.TitleScreen.Disable();
			_actions.TitleScreen.Start.performed -= OnStartPerformed;
			_view.Hide();
		}

		private void OnStartPerformed(InputAction.CallbackContext context)
		{
			UnityEngine.Debug.Log("--- START GAME ---");
			_signalBus.Fire(new GameStartedSignal());
		}
	}
}
