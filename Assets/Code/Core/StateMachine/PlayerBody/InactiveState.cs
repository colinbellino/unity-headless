using UnityEngine;
using Zenject;

namespace Greed.Core.StateMachines.PlayerBody
{
	public class InactiveState : State
	{
		private readonly SignalBus _signalBus;
		private readonly IPickUpHandler _pickUpHandler;
		private readonly LazyInject<StateMachine> _stateMachine;

		public InactiveState(
			SignalBus signalBus,
			IPickUpHandler pickerHandler,
			LazyInject<StateMachine> stateMachine
		)
		{
			_signalBus = signalBus;
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
			_signalBus.Fire<PlayerInputsDisabledSignal>();
			_signalBus.Unsubscribe<PlayerHeadRecalledSignal>(OnHeadRecalled);
		}

		private async void OnHeadRecalled()
		{
			var head = GameObject.Find("Player (Head)").GetComponent<IEntity>(); // Gross
			await _pickUpHandler.PickUp(head);
			_stateMachine.Value.Transition("Activate");
		}
	}
}
