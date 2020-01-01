using Zenject;

namespace Greed.Core
{
	public class PlayerMoveState : State
	{
		private readonly IEntityView _view;
		private readonly PickerHandler _pickUpHandler;
		private readonly InteractiveObjectFinder _objectFinder;
		private readonly EntityInputState _inputState;
		private readonly LazyInject<StateMachine> _stateMachine;

		private bool _isBusy;

		public PlayerMoveState(
			IEntityView view,
			PickerHandler pickUpHandler,
			InteractiveObjectFinder objectFinder,
			EntityInputState inputState,
			LazyInject<StateMachine> stateMachine
		)
		{
			_view = view;
			_pickUpHandler = pickUpHandler;
			_objectFinder = objectFinder;
			_inputState = inputState;
			_stateMachine = stateMachine;
		}

		public override void Tick()
		{
			if (_inputState.Interact)
			{
				InteractWithClosest();
			}
		}

		private void InteractWithClosest()
		{
			if (_isBusy)
			{
				return;
			}

			var objectToPickUp = _objectFinder.GetClosest(_view.Position);
			if (objectToPickUp != null)
			{
				// TODO: Handle other kind of interactions (in another class).
				PickUp(objectToPickUp);
			}
		}

		private async void PickUp(IEntity objectToPickUp)
		{
			_isBusy = true;

			await _pickUpHandler.PickUp(objectToPickUp);
			_stateMachine.Value.Transition("PickUp");

			_isBusy = false;
		}
	}
}
