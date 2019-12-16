using System;
using Greed.UnityWrapper;
using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class PickupHandler : IInitializable, ITickable, IDisposable
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;

		// FIXME: This is just here so we don't crash unity...
		// Replace with with a way to keep track of our collisions and trigger only enter/exit.
		// Maybe the monobehaviour enter/exit is better for this ?
		private bool _hitSomething;

		public PickupHandler(SignalBus signalBus, IEntity entity)
		{
			_signalBus = signalBus;
			_entity = entity;
		}

		public void Initialize()
		{
			_signalBus.Subscribe<PickUpStartedSignal>(PickUpStarted);
			_signalBus.Subscribe<ThrowStartedSignal>(ThrowStarted);
		}

		public void Dispose()
		{
			_signalBus.Unsubscribe<PickUpStartedSignal>(PickUpStarted);
			_signalBus.Unsubscribe<ThrowStartedSignal>(ThrowStarted);
		}

		public void Tick()
		{
			CheckForCollisions();
		}

		private void CheckForCollisions()
		{
			if (_hitSomething)
			{
				return;
			}

			var hits = GetStaticCollidersInRange();
			foreach (var hit in hits)
			{
				_signalBus.Fire(new CollisionHitSignal { Origin = _entity, Collider = Wrappers.Wrap(hit.collider) });
				_hitSomething = true;
			}
		}

		private RaycastHit2D[] GetStaticCollidersInRange()
		{
			var origin = _entity.View.Position;
			var radius = 1f;
			var direction = _entity.MoveDirection;
			var distance = 1f;
			var layerMask = LayerMask.GetMask("Static");

			return Physics2D.CircleCastAll(origin, radius, direction, distance, layerMask);
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
