using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class EntityMoveHandler : IFixedTickable
	{
		private readonly EntityInputState _inputState;
		private readonly IEntityView _view;
		private readonly ITime _time;

		private readonly int _speed = 6;

		public EntityMoveHandler(EntityInputState inputState, IEntityView view, ITime time)
		{
			_inputState = inputState;
			_view = view;
			_time = time;
		}

		public void FixedTick()
		{
			var move = new Vector3(_inputState.Move.x, _inputState.Move.y, 0f);
			_view.MovePosition(_view.Position + move * _speed * _time.FixedDeltaTime);
		}
	}
}
