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
		private readonly AudioPlayer _audioPlayer;
		private readonly VisualEffect _impactEffect;
		private readonly AudioClip _impactClip;

		public ImpactHandler(
			SignalBus signalBus,
			IEntity entity,
			VisualEffectsSpawner effectsManager,
			AudioPlayer audioPlayer,
			VisualEffect impactEffect,
			AudioClip impactClip
		)
		{
			_signalBus = signalBus;
			_entity = entity;
			_effectsManager = effectsManager;
			_impactEffect = impactEffect;
			_audioPlayer = audioPlayer;
			_impactClip = impactClip;
		}

		public void Initialize()
		{
			_signalBus.Subscribe<ImpactHitSignal>(CollisionHit);
		}

		public void Dispose()
		{
			_signalBus.Unsubscribe<ImpactHitSignal>(CollisionHit);
		}

		private void CollisionHit(ImpactHitSignal args)
		{
			(var origin, var other) = args;
			if (other == _entity)
			{
				return;
			}

			var canTriggerImpact = other.GameObject.IsStatic;

			if (canTriggerImpact == false)
			{
				return;
			}

			if (_impactEffect)
			{
				var pointOfImpact = other.ClosestPoint(origin.View.Position);
				_effectsManager.Create(_impactEffect, pointOfImpact, Quaternion.identity);
			}

			if (_impactClip)
			{
				_audioPlayer.PlayOneShot(_impactClip);
			}
		}
	}
}
