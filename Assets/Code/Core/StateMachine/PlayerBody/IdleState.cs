using Zenject;

namespace Greed.Core.StateMachines.PlayerBody
{
	public class IdleState : State
	{
		private readonly SignalBus _signalBus;
		private readonly EntityInputState _inputState;
		private readonly LazyInject<StateMachine> _stateMachine;

		public IdleState(
			SignalBus signalBus,
			EntityInputState inputState,
			LazyInject<StateMachine> stateMachine
		)
		{
			_signalBus = signalBus;
			_inputState = inputState;
			_stateMachine = stateMachine;
		}

		public override void OnEnter()
		{
			_signalBus.Fire<PlayerInputsEnabledSignal>();
		}

		public override void Tick()
		{
			if (_inputState.Interact)
			{
				_stateMachine.Value.Transition("Throw");
				return;
			}

			// TODO: Play idle animation after x seconds
			if (_inputState.Move.magnitude > 0f)
			{
				_stateMachine.Value.Transition("StartMoving");
				return;
			}
		}
	}
}
