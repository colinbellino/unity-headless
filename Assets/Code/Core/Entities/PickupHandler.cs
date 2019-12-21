using System;
using Greed.UnityWrapper;
using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class PickupHandler : IInitializable, IDisposable
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;

		public PickupHandler(SignalBus signalBus, IEntity entity)
		{
			_signalBus = signalBus;
			_entity = entity;
		}

		public void Initialize()
		{
			_entity.TriggerEntered += TriggerEntered;
			_signalBus.Subscribe<PickUpStartedSignal>(PickUpStarted);
			_signalBus.Subscribe<ThrowStartedSignal>(ThrowStarted);
		}

		public void Dispose()
		{
			_entity.TriggerEntered -= TriggerEntered;
			_signalBus.Unsubscribe<PickUpStartedSignal>(PickUpStarted);
			_signalBus.Unsubscribe<ThrowStartedSignal>(ThrowStarted);
		}

		private void TriggerEntered(ICollider2D collider)
		{
			var signal = new CollisionHitSignal { Origin = _entity, Collider = collider };
			_signalBus.Fire(signal);
		}

		private void PickUpStarted(PickUpStartedSignal args)
		{
			if (args.Target != _entity)
			{
				return;
			}

			_entity.View.AttachTo(args.Picker.PickupSlot);
			_entity.View.Velocity = Vector2.zero;
		}

		private void ThrowStarted(ThrowStartedSignal args)
		{
			if (args.Target != _entity)
			{
				return;
			}

			_entity.View.Detach();
			_entity.View.Velocity = Vector2.zero;

			var force = args.Force;
			_entity.View.AddForce(force, ForceMode2D.Impulse);
		}
	}
}
