using System;

namespace Greed.Core
{
	public class EntityPickUpHandler
	{
		private readonly IEntityView _view;

		private IEntity _cargo;

		public EntityPickUpHandler(IEntityView view)
		{
			_view = view;
		}

		public async void TryPickUp(IEntity objectToPickUp)
		{
			if (CanPickUpObject(objectToPickUp))
			{
				await _view.PlayAnimation("PickUp");
				_cargo = objectToPickUp;
				ChangeState("Encumbered");
				UnityEngine.Debug.Log("Picked up => " + _cargo);
			}
			else
			{
				await _view.PlayAnimation("PickUpFail");
				UnityEngine.Debug.Log("Failed to pick up => " + objectToPickUp);
			}
		}

		private void ChangeState(string stateName)
		{
			UnityEngine.Debug.Log("Changing state => " + stateName);
		}

		private bool CanPickUpObject(IEntity objectToPickUp)
		{
			return true;
		}
	}
}
