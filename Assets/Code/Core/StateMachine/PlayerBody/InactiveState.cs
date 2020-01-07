using Zenject;

namespace Greed.Core.StateMachines.PlayerBody
{
	public class InactiveState : State
	{
		private readonly SignalBus _signalBus;
		private readonly IPlayer _player;
		private readonly IPickUpHandler _pickUpHandler;
		private readonly LazyInject<StateMachine> _stateMachine;

		public InactiveState(
			SignalBus signalBus,
			IPlayer player,
			IPickUpHandler pickerHandler,
			LazyInject<StateMachine> stateMachine
		)
		{
			_signalBus = signalBus;
			_player = player;
			_pickUpHandler = pickerHandler;
			_stateMachine = stateMachine;
		}

		public override void OnEnter()
		{
			_signalBus.Fire<PlayerInputsDisabledSignal>();
			_signalBus.Subscribe<PlayerHeadRecalledSignal>(OnHeadRecalled);
		}

		public override void OnExit()
		{
			_signalBus.Unsubscribe<PlayerHeadRecalledSignal>(OnHeadRecalled);
		}

		private void OnHeadRecalled()
		{
			// TODO: Wait for animation
			_pickUpHandler.PickUp(_player.Head);
			_stateMachine.Value.Transition("Activate");
		}
	}
}
