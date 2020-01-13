using System;
using System.Threading.Tasks;
using Zenject;

namespace Greed.Core.StateMachines.Button
{
	public class InactiveState : State
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly LazyInject<StateMachine> _stateMachine;

		public InactiveState(
			IEntity entity,
			SignalBus signalBus,
			LazyInject<StateMachine> stateMachine
		)
		{
			_signalBus = signalBus;
			_entity = entity;
			_stateMachine = stateMachine;
		}

		public override async void OnEnter()
		{
			_signalBus.Subscribe<ButtonActivatedSignal>(OnActivated);

			// FIXME: Remove this once we have a way to activate them manually.
			await Task.Delay(TimeSpan.FromMilliseconds(500));
			var signal = new ButtonActivatedSignal { Target = _entity };
			_signalBus.Fire(signal);
		}

		public override void OnExit()
		{
			_signalBus.Unsubscribe<ButtonActivatedSignal>(OnActivated);
		}

		private void OnActivated(ButtonActivatedSignal args)
		{
			if (args.Target == _entity)
			{
				_stateMachine.Value.Transition("Activate");
			}
		}
	}
}
