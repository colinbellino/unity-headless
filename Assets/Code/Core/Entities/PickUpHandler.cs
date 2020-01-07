using UniRx.Async;
using UnityEngine;

namespace Greed.Core
{
	public class PickUpHandler : IPickUpHandler
	{
		private readonly IEntity _entity;

		private const string _pickUpAnimationName = "Pick Up";

		public PickUpHandler(IEntity entity)
		{
			_entity = entity;
		}

		public async UniTask PickUp(IEntity entityToPickUp)
		{
			entityToPickUp.View.AttachTo(_entity.PickupSlot);
			entityToPickUp.View.Velocity = Vector2.zero;

			_entity.CurrentPickup = entityToPickUp;

			await _entity.View.PlayAnimationTask(_pickUpAnimationName);
		}
	}
}
