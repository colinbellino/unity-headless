using UniRx.Async;
using Zenject;

namespace Greed.Core.StateMachines.PlayerHead
{
	public class RecalledState : State
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly LazyInject<StateMachine> _stateMachine;

		public RecalledState(
			SignalBus signalBus,
			IEntity entity,
			LazyInject<StateMachine> stateMachine
		)
		{
			_signalBus = signalBus;
			_entity = entity;
			_stateMachine = stateMachine;
		}

		public override async void OnEnter()
		{
			// TODO: Find a better way to get the player body.
			var body = UnityEngine.GameObject.Find("Player (Body)").GetComponent<IEntity>(); // Gross
			_entity.View.AttachTo(body.PickupSlot, false);
			await _entity.View.MoveToPosition(body.PickupSlot.Position, 0.3f);

			_signalBus.Fire<PlayerHeadRecalledSignal>();

			_stateMachine.Value.Transition("Done");
		}
	}
}
