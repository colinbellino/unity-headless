using System;
using System.Threading.Tasks;
using Zenject;

namespace Greed.Core.StateMachines.PlayerHead
{
	public class InactiveState : State
	{
		private readonly SignalBus _signalBus;
		private readonly LazyInject<StateMachine> _stateMachine;

		public InactiveState(
			SignalBus signalBus,
			LazyInject<StateMachine> stateMachine
		)
		{
			_signalBus = signalBus;
			_stateMachine = stateMachine;
		}

		public override void OnEnter()
		{
			_signalBus.Subscribe<PlayerHeadThrownSignal>(OnThrown);
		}

		public override void OnExit()
		{
			_signalBus.Unsubscribe<PlayerHeadThrownSignal>(OnThrown);
		}

		private async void OnThrown()
		{
			await Task.Delay(TimeSpan.FromMilliseconds(300));

			// TODO: play activate animation?
			_stateMachine.Value.Transition("Throw");
		}
	}
}
