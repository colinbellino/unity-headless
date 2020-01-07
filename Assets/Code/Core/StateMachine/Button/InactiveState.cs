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
			_entity.View.PlayAnimation("Off");

			_signalBus.Subscribe<ButtonActivatedSignal>(OnActivated);

			// FIXME: Remove this once we have a way to activate them manually.
			await Task.Delay(TimeSpan.FromMilliseconds(300));
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

	public class OnState : State
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly LazyInject<StateMachine> _stateMachine;

		public OnState(
			IEntity entity,
			SignalBus signalBus,
			LazyInject<StateMachine> stateMachine
		)
		{
			_signalBus = signalBus;
			_entity = entity;
			_stateMachine = stateMachine;
		}

		public override void OnEnter()
		{
			_entity.View.PlayAnimation("On");

			_signalBus.Subscribe<ButtonToggledSignal>(OnActivated);
		}

		public override void OnExit()
		{
			_signalBus.Unsubscribe<ButtonToggledSignal>(OnActivated);
		}

		private void OnActivated(ButtonToggledSignal args)
		{
			if (args.Target == _entity)
			{
				_stateMachine.Value.Transition("Toggle");
			}
		}
	}

	public class OffState : State
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly LazyInject<StateMachine> _stateMachine;

		public OffState(
			IEntity entity,
			SignalBus signalBus,
			LazyInject<StateMachine> stateMachine
		)
		{
			_signalBus = signalBus;
			_entity = entity;
			_stateMachine = stateMachine;
		}

		public override void OnEnter()
		{
			_entity.View.PlayAnimation("Off");

			_signalBus.Subscribe<ButtonToggledSignal>(OnActivated);
		}

		public override void OnExit()
		{
			_signalBus.Unsubscribe<ButtonToggledSignal>(OnActivated);
		}

		private void OnActivated(ButtonToggledSignal args)
		{
			if (args.Target == _entity)
			{
				_stateMachine.Value.Transition("Toggle");
			}
		}
	}
}
