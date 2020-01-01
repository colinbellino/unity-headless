using Zenject;

namespace Greed.Core
{
	public class ThrowState : State
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly IStats _stats;
		private readonly LazyInject<StateMachine> _stateMachine;

		private const string _throwAnimationName = "Throw";

		public ThrowState(
			IEntity entity,
			IStats stats,
			SignalBus signalBus,
			LazyInject<StateMachine> stateMachine
		)
		{
			_entity = entity;
			_stats = stats;
			_signalBus = signalBus;
			_stateMachine = stateMachine;
		}

		public override async void OnEnter()
		{
			var force = _entity.MoveDirection * _stats.ThrowForce;
			var signal = new ThrowStartedSignal { Picker = _entity, Target = _entity.CurrentPickup, Force = force };
			_signalBus.Fire(signal);

			_entity.CurrentPickup = null;

			await _entity.View.PlayAnimation(_throwAnimationName);

			_stateMachine.Value.Transition("Done");
		}
	}
}
