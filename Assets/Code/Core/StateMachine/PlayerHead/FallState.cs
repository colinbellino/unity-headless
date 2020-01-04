using UnityEngine;
using Zenject;

namespace Greed.Core.StateMachines.PlayerHead
{
	public class FallState : State
	{
		private readonly SignalBus _signalBus;
		private readonly EntityInputState _inputState;
		private readonly IEntity _entity;
		private readonly IMoveHandler _moveHandler;
		private readonly LazyInject<StateMachine> _stateMachine;

		public FallState(
			SignalBus signalBus,
			EntityInputState inputState,
			IEntity entity,
			IMoveHandler moveHandler,
			LazyInject<StateMachine> stateMachine
		)
		{
			_signalBus = signalBus;
			_inputState = inputState;
			_entity = entity;
			_moveHandler = moveHandler;
			_stateMachine = stateMachine;
		}

		public override void OnEnter()
		{
			_entity.View.Velocity = Vector3.zero;

			_signalBus.Fire<PlayerInputsDisabledSignal>();

			_entity.View.SetAnimationTrigger("Fall");
		}
	}
}
