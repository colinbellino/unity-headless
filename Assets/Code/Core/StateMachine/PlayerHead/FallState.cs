using UniRx.Async;
using UnityEngine;
using Zenject;

namespace Greed.Core.StateMachines.PlayerHead
{
	public class FallState : State
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly LazyInject<StateMachine> _stateMachine;

		public FallState(
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
			_entity.View.Velocity = Vector3.zero;
			_entity.View.PlayAnimation("Fall");

			await System.Threading.Tasks.Task.Delay(1000);

			_signalBus.Fire<PlayerInputsDisabledSignal>();
			_stateMachine.Value.Transition("Done");
		}
	}
}
