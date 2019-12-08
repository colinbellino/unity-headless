using System;
using System.Collections.Generic;
using Zenject;

namespace Greed.Core
{
	public class PlayerController : IInitializable, ITickable
	{
		private readonly EntityPickUpHandler _pickUpHandler;
		private readonly EntityInputState _inputState;
		private readonly InteractiveObjectFinder _finder;
		private readonly IEntityView _view;

		public PlayerController(
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

		public void Initialize()
		{
			var idleState = new IdleState(_view, new Dictionary<string, Type>
			{ //
				{ "PickUp", typeof(EncumberedState) }
			});
			var encumberedState = new EncumberedState(_view, new Dictionary<string, Type>
			{ //
				{ "Throw", typeof(IdleState) }
			});

			var states = new State[] { idleState, encumberedState };

			var bla = new StateMachine(states);
			// bla.Transition("PickUp");
			// bla.Transition("Throw");
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
