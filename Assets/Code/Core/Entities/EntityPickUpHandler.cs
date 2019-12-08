using UniRx.Async;

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

		public async UniTask<bool> TryPickUp(IEntity objectToPickUp)
		{
			// TODO: Prevent player input during animation.
			if (!CanPickUpObject(objectToPickUp))
			{
				await _view.PlayAnimation("PickUpFail");
				UnityEngine.Debug.Log("Failed to pick up => " + objectToPickUp);
				return false;
			}

			await _view.PlayAnimation("PickUp");
			_cargo = objectToPickUp;
			UnityEngine.Debug.Log("Picked up => " + _cargo);
			return true;
		}

		private bool CanPickUpObject(IEntity objectToPickUp)
		{
			return true;
		}
	}
}
