using Zenject;

namespace Greed.Core.StateMachines.Button
{
	public class OffState : State
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly LazyInject<StateMachine> _stateMachine;

		public OffState(
			IEntity entity,
			SignalBus signalBus,
			LazyInject<StateMachine> stateMachine
		)
		{
			_signalBus = signalBus;
			_entity = entity;
			_stateMachine = stateMachine;
		}

		public override void OnEnter()
		{
			_entity.View.PlayAnimation("Off");

			_signalBus.Subscribe<ButtonToggledSignal>(OnActivated);
		}

		public override void OnExit()
		{
			_signalBus.Unsubscribe<ButtonToggledSignal>(OnActivated);
		}

		private void OnActivated(ButtonToggledSignal args)
		{
			if (args.Target == _entity)
			{
				_stateMachine.Value.Transition("Toggle");
			}
		}
	}
}
