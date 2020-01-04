using Zenject;

namespace Greed.Core.StateMachines.PlayerHead
{
	public class IdleState : State
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly EntityInputState _inputState;
		private readonly LazyInject<StateMachine> _stateMachine;

		public IdleState(
			SignalBus signalBus,
			IEntity entity,
			EntityInputState inputState,
			LazyInject<StateMachine> stateMachine
		)
		{
			_signalBus = signalBus;
			_entity = entity;
			_inputState = inputState;
			_stateMachine = stateMachine;
		}

		public override void OnEnter()
		{
			// Hack to make sure the trigger are checked again.
			_entity.View.PhysicsCollider.Enabled = false;
			_entity.View.PhysicsCollider.Enabled = true;

			_signalBus.Fire<PlayerInputsEnabledSignal>();
			_signalBus.Subscribe<FellSignal>(OnFell);
		}

		// TODO: Play idle animation after x seconds
		public override void Tick()
		{
			if (_inputState.Interact)
			{
				_stateMachine.Value.Transition("Recall");
				return;
			}

			if (_inputState.Move.magnitude > 0f)
			{
				_stateMachine.Value.Transition("StartMoving");
				return;
			}

			base.Tick();
		}

		public override void OnExit()
		{
			_signalBus.Unsubscribe<FellSignal>(OnFell);
		}

		private void OnFell(FellSignal args)
		{
			if (args.Target.Equals(_entity))
			{
				_stateMachine.Value.Transition("Fall");
			}
		}
	}
}
