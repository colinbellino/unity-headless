using Zenject;

namespace Greed.Core.StateMachines.PlayerHead
{
	public class ThrownState : State
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly ImpactHandler _impactHandler;
		private readonly LazyInject<StateMachine> _stateMachine;

		private const float _immobileThreshold = 1f;

		public ThrownState(
			SignalBus signalBus,
			IEntity entity,
			ImpactHandler impactHandler,
			LazyInject<StateMachine> stateMachine
		)
		{
			_signalBus = signalBus;
			_entity = entity;
			_impactHandler = impactHandler;
			_stateMachine = stateMachine;
		}

		public override void OnEnter()
		{
			_impactHandler.Enable();
			_signalBus.Subscribe<ImpactHitSignal>(OnImpactHit);
		}

		public override void Tick()
		{
			if (_entity.View.Velocity.magnitude < _immobileThreshold)
			{
				Done();
			}
		}

		public override void OnExit()
		{
			_impactHandler.Disable();
			_signalBus.Unsubscribe<ImpactHitSignal>(OnImpactHit);
		}

		private void OnImpactHit(ImpactHitSignal args)
		{
			if (args.Origin == _entity)
			{
				Done();
				return;
			}
		}

		private void Done()
		{
			_stateMachine.Value.Transition("Done");
		}
	}
}
