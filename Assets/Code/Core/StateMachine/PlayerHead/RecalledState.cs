using System;
using System.Threading.Tasks;
using Zenject;

namespace Greed.Core.StateMachines.PlayerHead
{
	public class RecalledState : State
	{
		protected readonly SignalBus _signalBus;
		private readonly LazyInject<StateMachine> _stateMachine;

		public RecalledState(
			SignalBus signalBus,
			LazyInject<StateMachine> stateMachine
		)
		{
			_signalBus = signalBus;
			_stateMachine = stateMachine;
		}

		public override async void OnEnter()
		{
			// TODO: Animate this
			await Task.Delay(TimeSpan.FromMilliseconds(400));

			_signalBus.Fire<PlayerHeadRecalledSignal>();

			_stateMachine.Value.Transition("Done");
		}
	}
}
