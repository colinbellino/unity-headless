using Zenject;

namespace Greed.Core.StateMachines.Button
{
	public class OffState : State
	{
		private readonly SignalBus _signalBus;
		private readonly IEntityView _view;
		private readonly IPowerSource _powerSource;
		private readonly LazyInject<StateMachine> _stateMachine;

		public OffState(
			SignalBus signalBus,
			IEntityView view,
			IPowerSource powerSource,
			LazyInject<StateMachine> stateMachine
		)
		{
			_signalBus = signalBus;
			_view = view;
			_powerSource = powerSource;
			_stateMachine = stateMachine;
		}

		public override void OnEnter()
		{
			_view.PlayAnimation("Off");

			_signalBus.Subscribe<PowerSourceToggledSignal>(OnActivated);
		}

		public override void OnExit()
		{
			_signalBus.Unsubscribe<PowerSourceToggledSignal>(OnActivated);
		}

		private void OnActivated(PowerSourceToggledSignal args)
		{
			if (args.Source == _powerSource)
			{
				_stateMachine.Value.Transition("Toggle");
			}
		}
	}
}
