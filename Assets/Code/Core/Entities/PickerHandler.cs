using Greed.UnityWrapper;
using UniRx.Async;
using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class PickerHandler
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly IEntityView _view;
		private readonly ITransform _pickupSlot;

		private const string _pickUpAnimationName = "Pick Up";
		private const string _throwAnimationName = "Throw";

		private IEntity _currentPickup;

		public PickerHandler(SignalBus signalBus, IEntity entity, IEntityView view, ITransform carrySlot)
		{
			_signalBus = signalBus;
			_entity = entity;
			_view = view;
			_pickupSlot = carrySlot;
		}

		public async UniTask PickUp(IEntity entityToPickUp)
		{
			_signalBus.Fire(new PickUpStartedSignal { Picker = _entity, Target = entityToPickUp });

			await _view.PlayAnimation(_pickUpAnimationName);
			entityToPickUp.View.AttachTo(_pickupSlot);
			_currentPickup = entityToPickUp;

			_signalBus.Fire(new PickUpEndedSignal { Picker = _entity, Target = entityToPickUp });
		}

		public async UniTask Throw(Vector2 force)
		{
			_signalBus.Fire(new ThrowStartedSignal { Picker = _entity, Target = _currentPickup });

			_currentPickup.View.Detach();
			_currentPickup.View.AddForce(force, ForceMode2D.Impulse);
			_currentPickup = null;
			await _view.PlayAnimation(_throwAnimationName);

			_signalBus.Fire(new ThrowEndedSignal { Picker = _entity, Target = _currentPickup });
		}
	}

	// TODO: Move to Signals/
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

	public class ThrowStartedSignal
	{
		public IEntity Picker;
		public IEntity Target;
	}

	public class ThrowEndedSignal
	{
		public IEntity Picker;
		public IEntity Target;
	}
}
