using Greed.UnityWrapper;
using Zenject;

namespace Greed.Core
{
	public class MoveTowardsTarget : ITickable
	{
		private readonly IEntityView _view;
		private readonly IEntity _target;
		private readonly ITime _time;
		private readonly int _moveSpeed;

		public MoveTowardsTarget(
			IEntityView view,
			IEntity target,
			ITime time,
			int moveSpeed
		)
		{
			_view = view;
			_target = target;
			_time = time;
			_moveSpeed = moveSpeed;
		}

		public void Tick()
		{
			var step = _moveSpeed * _time.DeltaTime;
			_view.MoveTowards(_target.View.Position, step);
		}
	}
}
