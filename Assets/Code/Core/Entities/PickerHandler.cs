using Greed.UnityWrapper;
using UniRx.Async;
using Zenject;

namespace Greed.Core
{
	public class PickerHandler
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly IEntityView _view;
		private readonly ITransform _pickupSlot;

		private const string _pickUpAnimationState = "Pick Up";

		public PickerHandler(SignalBus signalBus, IEntity entity, IEntityView view, ITransform carrySlot)
		{
			_signalBus = signalBus;
			_entity = entity;
			_view = view;
			_pickupSlot = carrySlot;
		}

		public async UniTask TryPickUp(IEntity entityToPickUp)
		{
			_signalBus.Fire(new PickUpStartedSignal { Picker = _entity, Target = entityToPickUp });

			await _view.PlayAnimation(_pickUpAnimationState);
			entityToPickUp.View.AttachTo(_pickupSlot);

			_signalBus.Fire(new PickUpEndedSignal { Picker = _entity, Target = entityToPickUp });
		}
	}

	public class PickUpStartedSignal
	{
		public IEntity Picker;
		public IEntity Target;
	}

	public class PickUpEndedSignal
	{
		public IEntity Picker;
		public IEntity Target;
	}
}
