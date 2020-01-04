using Zenject;

namespace Greed.Core.StateMachines.PlayerHead
{
	public class InactiveState : State
	{
		private readonly IEntity _entity;
		private readonly SignalBus _signalBus;
		private readonly LazyInject<StateMachine> _stateMachine;

		public InactiveState(
			SignalBus signalBus,
			IEntity entity,
			LazyInject<StateMachine> stateMachine
		)
		{
			_signalBus = signalBus;
			_entity = entity;
			_stateMachine = stateMachine;
		}

		public override void OnEnter()
		{
			_signalBus.Subscribe<PlayerHeadThrownSignal>(OnThrown);
			_signalBus.Subscribe<FellSignal>(OnFell);
		}

		public override void OnExit()
		{
			_signalBus.Unsubscribe<PlayerHeadThrownSignal>(OnThrown);
			_signalBus.Unsubscribe<FellSignal>(OnFell);
		}

		// TODO: play activate animation?
		private void OnThrown()
		{
			_stateMachine.Value.Transition("Throw");
		}

		private void OnFell(FellSignal args)
		{
			if (args.Target.Equals(_entity))
			{
				_stateMachine.Value.Transition("Fall");
			}
		}
	}
}
