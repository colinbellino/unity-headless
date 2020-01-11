using Zenject;

namespace Greed.Core.StateMachines.Door
{
	public class OpeningState : State
	{
		private readonly SignalBus _signalBus;
		private readonly IEntityView _view;
		private readonly IPowered _powered;
		private readonly LazyInject<StateMachine> _stateMachine;

		public OpeningState(
			SignalBus signalBus,
			IEntityView view,
			IPowered powered,
			LazyInject<StateMachine> stateMachine
		)
		{
			_signalBus = signalBus;
			_view = view;
			_powered = powered;
			_stateMachine = stateMachine;
		}

		public override void OnEnter()
		{
			_view.PlayAnimation("Opened");

			// _signalBus.Subscribe<PoweredToggledSignal>(OnActivated);
		}

		public override void OnExit()
		{
			// _signalBus.Unsubscribe<PoweredToggledSignal>(OnActivated);
		}

		private void OnActivated(PoweredToggledSignal args)
		{
			if (args.Powered == _powered)
			{
				_stateMachine.Value.Transition("Toggle");
			}
		}
	}
}
