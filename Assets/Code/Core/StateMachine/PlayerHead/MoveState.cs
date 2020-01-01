using Zenject;

namespace Greed.Core.StateMachines.PlayerHead
{
	public class MoveState : State
	{
		private readonly EntityInputState _inputState;
		private readonly IEntity _entity;
		private readonly IMoveHandler _moveHandler;
		private readonly LazyInject<StateMachine> _stateMachine;

		public MoveState(
			EntityInputState inputState,
			IEntity entity,
			IMoveHandler moveHandler,
			LazyInject<StateMachine> stateMachine
		)
		{
			_inputState = inputState;
			_entity = entity;
			_moveHandler = moveHandler;
			_stateMachine = stateMachine;
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
	}
}
