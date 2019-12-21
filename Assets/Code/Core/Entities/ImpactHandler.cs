using System;
using Greed.UnityWrapper;
using UnityEngine;
using UnityEngine.VFX;
using Zenject;

namespace Greed.Core
{
	public class ImpactHandler : IInitializable, IDisposable
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly VisualEffectsSpawner _effectsManager;
		private readonly VisualEffect _impactEffect;

		public ImpactHandler(
			SignalBus signalBus,
			IEntity entity,
			VisualEffectsSpawner effectsManager,
			VisualEffect impactEffect
		)
		{
			_signalBus = signalBus;
			_entity = entity;
			_effectsManager = effectsManager;
			_impactEffect = impactEffect;
		}

		public void Initialize()
		{
			_signalBus.Subscribe<CollisionHitSignal>(CollisionHit);
		}

		public void Dispose()
		{
			_signalBus.Unsubscribe<CollisionHitSignal>(CollisionHit);
		}

		private void CollisionHit(CollisionHitSignal args)
		{
			(var origin, var collider) = args;

			if (!CanImpact(collider))
			{
				return;
			}

			if (_impactEffect == null)
			{
				Debug.LogWarning($"Missing impact effect for {_entity.Name}");
				return;
			}

			var pointOfImpact = collider.ClosestPoint(origin.View.Position);
			_effectsManager.Create(_impactEffect, pointOfImpact, Quaternion.identity);
		}

		private bool CanImpact(ICollider2D collider)
		{
			return collider != _entity && collider.GameObject.IsStatic;
		}
	}
}
