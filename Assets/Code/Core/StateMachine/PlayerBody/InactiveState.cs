using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class InactiveState : State
	{
		private readonly SignalBus _signalBus;
		private readonly IPickUpHandler _pickUpHandler;
		private readonly PlayerActions _playerActions;
		private readonly LazyInject<StateMachine> _stateMachine;

		private bool _activating;

		public InactiveState(
			SignalBus signalBus,
			IPickUpHandler pickerHandler,
			PlayerActions playerActions,
			LazyInject<StateMachine> stateMachine
		)
		{
			_signalBus = signalBus;
			_pickUpHandler = pickerHandler;
			_playerActions = playerActions;
			_stateMachine = stateMachine;
		}

		public override async void OnEnter()
		{
			_signalBus.Fire<PlayerInputsDisabledSignal>();
		}

		public override void Tick()
		{
			if (_activating == false && _playerActions.Debug.Debug1.ReadValue<float>() > 0f)
			{
				PickUpHeadAndActivate();
				_activating = true;
			}
		}

		public override void OnExit()
		{
			_activating = false;

			_signalBus.Fire<PlayerInputsDisabledSignal>();
		}

		private async void PickUpHeadAndActivate()
		{
			var head = GameObject.Find("Player (Head)").GetComponent<IEntity>(); // Gross

			await _pickUpHandler.PickUp(head);

			_stateMachine.Value.Transition("Activate");
		}
	}
}
