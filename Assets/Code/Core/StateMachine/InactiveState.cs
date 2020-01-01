using System.Threading.Tasks;
using Zenject;

namespace Greed.Core
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

		public override async void OnEnter()
		{
			_signalBus.Fire<PlayerInputsDisabledSignal>();

			// TODO: Use an event to trigger the activation.
			await Task.Delay(2);
			_stateMachine.Value.Transition("Activate");
		}
	}
}
