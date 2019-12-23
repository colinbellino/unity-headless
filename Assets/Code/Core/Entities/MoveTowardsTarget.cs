using Greed.UnityWrapper;
using Zenject;

namespace Greed.Core
{
	public class MoveTowardsTarget : ITickable
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly IEntity _target;
		private readonly ITime _time;
		private readonly int _moveSpeed;

		public MoveTowardsTarget(
			SignalBus signalBus,
			IEntity entity,
			IEntity target,
			ITime time,
			int moveSpeed
		)
		{
			_signalBus = signalBus;
			_entity = entity;
			_target = target;
			_time = time;
			_moveSpeed = moveSpeed;
		}

		public void Tick()
		{
			var step = _moveSpeed * _time.DeltaTime;
			_entity.View.MoveTowards(_target.View.Position, step);
		}
	}
}
