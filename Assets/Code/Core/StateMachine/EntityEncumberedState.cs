using Zenject;

namespace Greed.Core
{
	public class EntityEncumberedState : State
	{
		private readonly PickerHandler _pickUpHandler;
		private readonly EntityInputState _inputState;
		private readonly LazyInject<StateMachine> _stateMachine;

		private bool _isBusy;

		public EntityEncumberedState(
			PickerHandler pickUpHandler,
			EntityInputState inputState,
			LazyInject<StateMachine> stateMachine
		)
		{
			_pickUpHandler = pickUpHandler;
			_inputState = inputState;
			_stateMachine = stateMachine;
		}

		public override void Tick()
		{
			// if (_inputState.Interact)
			// {
			// 	ThrowPickup();
			// }
		}

		// private async void ThrowPickup()
		// {
		// 	if (_isBusy)
		// 	{
		// 		return;
		// 	}

		// 	_isBusy = true;

		// 	await _pickUpHandler.Throw();
		// 	_stateMachine.Value.Transition("Throw");

		// 	_isBusy = false;
		// }
	}
}
