using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class EntityMoveHandler : IFixedTickable
	{
		private readonly EntityInputState _inputState;
		private readonly IEntityView _view;

		private readonly int _speed = 1;

		public EntityMoveHandler(EntityInputState inputState, IEntityView view)
		{
			_inputState = inputState;
			_view = view;
		}

		public void FixedTick()
		{
			var move = new Vector3(_inputState.Move.x, _inputState.Move.y, 0f);
			_view.MovePosition(_view.Position + move * _speed);
		}
	}
}
