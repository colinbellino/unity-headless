using Greed.UnityWrapper;
using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class MoveHandler : ITickable, IFixedTickable, IMoveDirection
	{
		private readonly EntityInputState _inputState;
		private readonly IEntityView _view;
		private readonly ITime _time;
		private readonly int _speed;

		public Vector3 MoveDirection { get; private set; }
		private Vector3 _move;

		public MoveHandler(EntityInputState inputState, IEntityView view, ITime time, int speed)
		{
			_inputState = inputState;
			_view = view;
			_time = time;
			_speed = speed;
		}

		public void Tick()
		{
			_move = new Vector3(_inputState.Move.x, _inputState.Move.y, 0f);

			// TODO: Maybe we shouldn't do this in this class?
			if (_move.magnitude > 0f)
			{
				_view.SetAnimationFloat("MoveX", _move.x);
				_view.SetAnimationFloat("MoveY", _move.y);

				MoveDirection = _move.normalized;
			}
		}

		public void FixedTick()
		{
			if (_speed == 0)
			{
				return;
			}

			_view.MovePosition(_view.Position + _move * _speed * _time.FixedDeltaTime);
		}
	}
}