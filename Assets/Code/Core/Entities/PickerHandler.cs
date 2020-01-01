using Greed.UnityWrapper;
using UniRx.Async;
using UnityEngine;

namespace Greed.Core
{
	public class PickUpHandler : IPickUpHandler
	{
		private readonly IEntity _entity;
		private readonly ITransform _pickupSlot;

		private const string _pickUpAnimationName = "Pick Up";

		public PickUpHandler(IEntity entity, ITransform pickupSlot)
		{
			_entity = entity;
			_pickupSlot = pickupSlot;
		}

		public async UniTask PickUp(IEntity entityToPickUp)
		{
			entityToPickUp.View.AttachTo(_pickupSlot);
			entityToPickUp.View.Velocity = Vector2.zero;

			_entity.CurrentPickup = entityToPickUp;

			await _entity.View.PlayAnimation(_pickUpAnimationName);
		}
	}
}
