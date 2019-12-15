using System;
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
		private readonly float _throwForce;

		private const string _pickUpAnimationName = "Pick Up";
		private const string _throwAnimationName = "Throw";

		private IEntity _currentPickup;

		public ITransform PickupSlot => _pickupSlot;

		public PickerHandler(
			SignalBus signalBus,
			IEntity entity,
			IEntityView view,
			ITransform pickupSlot,
			float throwForce
		)
		{
			_signalBus = signalBus;
			_entity = entity;
			_view = view;
			_pickupSlot = pickupSlot;
			_throwForce = throwForce;
		}

		public async UniTask PickUp(IEntity entityToPickUp)
		{
			_signalBus.Fire(new PickUpStartedSignal { Picker = _entity, Target = entityToPickUp });

			_currentPickup = entityToPickUp;
			await _view.PlayAnimation(_pickUpAnimationName);

			_signalBus.Fire(new PickUpEndedSignal { Picker = _entity, Target = entityToPickUp });
		}

		public async UniTask Throw()
		{
			var force = _entity.MoveDirection * _throwForce;
			_signalBus.Fire(new ThrowStartedSignal { Picker = _entity, Target = _currentPickup, Force = force });

			_currentPickup = null;
			_view.PlayAnimation(_throwAnimationName);
			await UniTask.Delay(TimeSpan.FromMilliseconds(200));

			_signalBus.Fire(new ThrowEndedSignal { Picker = _entity, Target = _currentPickup });
		}
	}
}
