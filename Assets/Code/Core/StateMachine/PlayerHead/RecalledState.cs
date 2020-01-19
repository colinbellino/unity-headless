using UniRx.Async;
using Zenject;

namespace Greed.Core.StateMachines.PlayerHead
{
	public class RecalledState : State
	{
		private readonly SignalBus _signalBus;
		private readonly IEntityView _view;
		private readonly IPlayer _player;
		private readonly LazyInject<StateMachine> _stateMachine;

		public RecalledState(
			SignalBus signalBus,
			IEntityView view,
			IPlayer player,
			LazyInject<StateMachine> stateMachine
		)
		{
			_signalBus = signalBus;
			_view = view;
			_player = player;
			_stateMachine = stateMachine;
		}

		public override async void OnEnter()
		{
			// TODO: Animate recall
			_view.PlayAnimation("Idle");
			await _view.MoveToPosition(_player.Body.PickupSlot.Position, 0.3f);

			_signalBus.Fire<PlayerHeadRecalledSignal>();

			_stateMachine.Value.Transition("Done");
		}
	}
}
