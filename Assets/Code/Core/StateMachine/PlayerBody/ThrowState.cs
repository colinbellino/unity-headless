using System;
using Zenject;

namespace Greed.Core
{
	public class ThrowState : State
	{
		private readonly IEntity _entity;
		private readonly IThrowHandler _throwHandler;
		private readonly LazyInject<StateMachine> _stateMachine;

		public ThrowState(
			IEntity entity,
			IThrowHandler throwHandler,
			LazyInject<StateMachine> stateMachine
		)
		{
			_entity = entity;
			_throwHandler = throwHandler;
			_stateMachine = stateMachine;
		}

		public override async void OnEnter()
		{
			await _throwHandler.Throw(_entity.CurrentPickup, _entity.MoveDirection);

			_stateMachine.Value.Transition("Done");
		}
	}
}
