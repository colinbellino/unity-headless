using Zenject;

namespace Greed.Core
{
	public class MoveState : State
	{
		private readonly IEntity _entity;
		private readonly IMoveHandler _moveHandler;
		private readonly EntityInputState _inputState;
		private readonly LazyInject<StateMachine> _stateMachine;

		public MoveState(
			IEntity entity,
			IMoveHandler moveHandler,
			EntityInputState inputState,
			LazyInject<StateMachine> stateMachine
		)
		{
			_entity = entity;
			_moveHandler = moveHandler;
			_inputState = inputState;
			_stateMachine = stateMachine;
		}

		public override void Tick()
		{
			if (_inputState.Interact)
			{
				_stateMachine.Value.Transition("Throw");
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
	}
}
