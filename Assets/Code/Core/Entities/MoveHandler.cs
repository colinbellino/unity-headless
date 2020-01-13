using Greed.UnityWrapper;
using UnityEngine;

namespace Greed.Core
{
	public class MoveHandler : IMoveHandler
	{
		private readonly IEntityView _view;
		private readonly ITime _time;
		private readonly int _speed;

		public MoveHandler(IEntityView view, ITime time, int speed)
		{
			_view = view;
			_time = time;
			_speed = speed;
		}

		public void Move(Vector3 moveInput)
		{
			_view.MovePosition(_view.Position + moveInput * _speed * _time.FixedDeltaTime);
		}
	}
}
