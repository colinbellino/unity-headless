using Zenject;

namespace Greed.Core
{
	public class PlayerStateMachineController : ITickable
	{
		private readonly EntityPickUpHandler _pickUpHandler;
		private readonly EntityInputState _inputState;
		private readonly InteractiveObjectFinder _finder;
		private readonly IEntityView _view;

		public PlayerStateMachineController(
			EntityPickUpHandler pickUpHandler,
			EntityInputState inputState,
			InteractiveObjectFinder finder,
			IEntityView view
		)
		{
			_pickUpHandler = pickUpHandler;
			_inputState = inputState;
			_finder = finder;
			_view = view;
		}

		public void Tick()
		{
			if (_inputState.Interact)
			{
				var objectToPickUp = _finder.GetClosest(_view.Position);
				if (objectToPickUp != null)
				{
					_pickUpHandler.TryPickUp(objectToPickUp);
				}
			}
		}
	}
}
