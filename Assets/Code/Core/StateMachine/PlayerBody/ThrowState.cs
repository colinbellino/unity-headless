using Zenject;

namespace Greed.Core.StateMachines.PlayerBody
{
	public class ThrowState : State
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly IThrowHandler _throwHandler;
		private readonly LazyInject<StateMachine> _stateMachine;

		public ThrowState(
			IEntity entity,
			SignalBus signalBus,
			IThrowHandler throwHandler,
			LazyInject<StateMachine> stateMachine
		)
		{
			_signalBus = signalBus;
			_entity = entity;
			_throwHandler = throwHandler;
			_stateMachine = stateMachine;
		}

		public override async void OnEnter()
		{
			_signalBus.Fire<PlayerInputsDisabledSignal>();

			await _throwHandler.Throw(_entity.CurrentPickup, _entity.MoveDirection);
			_signalBus.Fire<PlayerHeadThrownSignal>();

			_stateMachine.Value.Transition("Done");
		}
	}
}
