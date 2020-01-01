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
			_signalBus.Subscribe<PlayerInputsEnabledSignal>(EnableDefaultActions);
			_signalBus.Subscribe<PlayerInputsDisabledSignal>(EnableDefaultActions);
		}

		public void Tick()
		{
			_inputState.Move = _actions.Default.Move.ReadValue<Vector2>();
			_inputState.Interact = _actions.Default.Interact.ReadValue<float>() > 0f;
		}

		public void Dispose()
		{
			_signalBus.Unsubscribe<PlayerInputsEnabledSignal>(EnableDefaultActions);
			_signalBus.Unsubscribe<PlayerInputsDisabledSignal>(DisableDefaultActions);
		}

		private void EnableDefaultActions() => _actions.Default.Enable();

		private void DisableDefaultActions() => _actions.Default.Disable();
	}
}
