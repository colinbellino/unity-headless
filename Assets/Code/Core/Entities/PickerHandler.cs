using Greed.UnityWrapper;
using UniRx.Async;
using Zenject;

namespace Greed.Core
{
	public class PickerHandler : IPickerHandler
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly IEntityView _view;
		private readonly ITransform _pickupSlot;

		private const string _pickUpAnimationName = "Pick Up";

		public ITransform PickupSlot => _pickupSlot;

		public PickerHandler(
			SignalBus signalBus,
			IEntity entity,
			IEntityView view,
			ITransform pickupSlot
		)
		{
			_signalBus = signalBus;
			_entity = entity;
			_view = view;
			_pickupSlot = pickupSlot;
		}

		public async UniTask PickUp(IEntity entityToPickUp)
		{
			_entity.CurrentPickup = entityToPickUp;

			_signalBus.Fire(new PickUpStartedSignal { Picker = _entity, Slot = _pickupSlot, Target = entityToPickUp });

			await _view.PlayAnimation(_pickUpAnimationName);
		}
	}
}
