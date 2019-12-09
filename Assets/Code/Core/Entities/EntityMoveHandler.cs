using Greed.UnityWrapper;
using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class EntityMoveHandler : IFixedTickable
	{
		private readonly EntityInputState _inputState;
		private readonly IEntityView _view;
		private readonly ITime _time;
		private readonly int _speed;

		public EntityMoveHandler(EntityInputState inputState, IEntityView view, ITime time, int speed)
		{
			_inputState = inputState;
			_view = view;
			_time = time;
			_speed = speed;
		}

		public void FixedTick()
		{
			if (_speed == 0)
			{
				return;
			}

			var move = new Vector3(_inputState.Move.x, _inputState.Move.y, 0f);
			_view.MovePosition(_view.Position + move * _speed * _time.FixedDeltaTime);
		}
	}
}
