using System;
using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class PlayerInputHandler : IInitializable, ITickable, IDisposable
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly EntityInputState _inputState;
		private readonly PlayerActions _actions;

		public PlayerInputHandler(SignalBus signalBus, IEntity entity, EntityInputState inputState, PlayerActions actions)
		{
			_signalBus = signalBus;
			_entity = entity;
			_inputState = inputState;
			_actions = actions;
		}

		public void Initialize()
		{
			_signalBus.Subscribe<GameStartedSignal>(EnableDefaultActions);
			_signalBus.Subscribe<PickUpStartedSignal>(PickUpStarted);
			_signalBus.Subscribe<PickUpEndedSignal>(PickUpEnded);
		}

		public void Tick()
		{
			_inputState.Move = _actions.Default.Move.ReadValue<Vector2>();
			_inputState.Interact = _actions.Default.Interact.ReadValue<float>() > 0f;
		}

		public void Dispose()
		{
			_signalBus.Unsubscribe<GameStartedSignal>(EnableDefaultActions);
			_signalBus.Unsubscribe<PickUpStartedSignal>(PickUpStarted);
			_signalBus.Unsubscribe<PickUpEndedSignal>(PickUpEnded);
		}

		private void PickUpStarted(PickUpStartedSignal args)
		{
			if (args.Actor == _entity)
			{
				DisableDefaultActions();
			}
		}

		private void PickUpEnded(PickUpEndedSignal args)
		{
			if (args.Actor == _entity)
			{
				EnableDefaultActions();
			}
		}

		private void EnableDefaultActions() => _actions.Default.Enable();

		private void DisableDefaultActions() => _actions.Default.Disable();
	}
}
