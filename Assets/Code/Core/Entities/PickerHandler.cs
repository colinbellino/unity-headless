using System;
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

		private const string _pickUpAnimationName = "Pick Up";
		private const string _throwAnimationName = "Throw";

		private IEntity _currentPickup;

		public ITransform PickupSlot;

		public PickerHandler(SignalBus signalBus, IEntity entity, IEntityView view, ITransform pickupSlot)
		{
			_signalBus = signalBus;
			_entity = entity;
			_view = view;
			PickupSlot = pickupSlot;
		}

		public async UniTask PickUp(IEntity entityToPickUp)
		{
			_signalBus.Fire(new PickUpStartedSignal { Picker = _entity, Target = entityToPickUp });

			_currentPickup = entityToPickUp;
			await _view.PlayAnimation(_pickUpAnimationName);

			_signalBus.Fire(new PickUpEndedSignal { Picker = _entity, Target = entityToPickUp });
		}

		public async UniTask Throw(Vector3 force)
		{
			_signalBus.Fire(new ThrowStartedSignal { Picker = _entity, Target = _currentPickup, Force = force });

			_currentPickup = null;
			_view.PlayAnimation(_throwAnimationName);
			await UniTask.Delay(TimeSpan.FromMilliseconds(200));

			_signalBus.Fire(new ThrowEndedSignal { Picker = _entity, Target = _currentPickup });
		}
	}
}
