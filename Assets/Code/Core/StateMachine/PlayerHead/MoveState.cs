using Zenject;

namespace Greed.Core.StateMachines.PlayerHead
{
	public class MoveState : State
	{
		private readonly SignalBus _signalBus;
		private readonly EntityInputState _inputState;
		private readonly IEntity _entity;
		private readonly IMoveHandler _moveHandler;
		private readonly LazyInject<StateMachine> _stateMachine;

		public MoveState(
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
			_signalBus.Subscribe<FellSignal>(OnFell);
		}

		public override void Tick()
		{
			if (_inputState.Interact)
			{
				_stateMachine.Value.Transition("Recall");
			}

			var move = _inputState.Move;
			if (move.magnitude > 0f)
			{
				_entity.View.SetAnimationFloat("MoveX", move.x);
				_entity.View.SetAnimationFloat("MoveY", move.y);

				_entity.MoveDirection = move.normalized;
			}
			else
			{
				_stateMachine.Value.Transition("StopMoving");
			}

			_moveHandler.Move(move);
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
