using System;
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
			if (args.Origin != _entity)
			{
				return;
			}

			if (_impactEffect == null)
			{
				return;
			}

			_effectsManager.Create(_impactEffect, args.Hit.Point, Quaternion.identity);
		}
	}
}
