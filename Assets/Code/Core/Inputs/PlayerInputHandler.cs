using System;
using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class PlayerInputHandler : IInitializable, ITickable, IDisposable
	{
		private readonly SignalBus _signalBus;
		private readonly EntityInputState _inputState;
		private readonly PlayerActions _actions;

		public PlayerInputHandler(SignalBus signalBus, EntityInputState inputState, PlayerActions actions)
		{
			_signalBus = signalBus;
			_inputState = inputState;
			_actions = actions;
		}

		public void Initialize()
		{
			_signalBus.Subscribe<GameStartedSignal>(OnGameStarted);
		}

		public void Dispose()
		{
			_signalBus.Unsubscribe<GameStartedSignal>(OnGameStarted);
		}

		private void OnGameStarted()
		{
			_actions.Default.Enable();
		}

		public void Tick()
		{
			_inputState.Move = _actions.Default.Move.ReadValue<Vector2>();
			_inputState.Interact = _actions.Default.Interact.ReadValue<float>() > 0f;
		}
	}
}
