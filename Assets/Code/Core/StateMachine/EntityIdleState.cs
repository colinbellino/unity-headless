using System;
using System.Collections.Generic;

namespace Greed.Core
{
	public class EntityIdleState : State
	{
		private readonly IEntityView _view;
		private readonly EntityPickUpHandler _pickUpHandler;
		private readonly InteractiveObjectFinder _objectFinder;
		private readonly EntityInputState _inputState;

		private bool _isBusy;

		public EntityIdleState(
			IEntityView view,
			EntityPickUpHandler pickUpHandler,
			InteractiveObjectFinder objectFinder,
			EntityInputState inputState,
			Dictionary<string, Type> transitions
		) : base(transitions)
		{
			_view = view;
			_pickUpHandler = pickUpHandler;
			_objectFinder = objectFinder;
			_inputState = inputState;
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

			var wasSuccessful = await _pickUpHandler.TryPickUp(objectToPickUp);
			if (wasSuccessful)
			{
				OnTransition("PickUp");
			}

			_isBusy = false;
		}
	}
}
