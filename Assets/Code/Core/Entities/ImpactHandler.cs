using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Greed.Core
{
	public class ImpactHandler
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly VisualEffectsSpawner _effectsManager;
		private readonly AudioPlayer _audioPlayer;
		private readonly AssetReference _impactEffect;
		private readonly AudioClip _impactClip;

		public ImpactHandler(
			SignalBus signalBus,
			IEntity entity,
			VisualEffectsSpawner effectsManager,
			AudioPlayer audioPlayer,
			AssetReference impactEffect,
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

		public void Enable()
		{
			_entity.View.PhysicsCollider.Enabled = false;
			_signalBus.Subscribe<ImpactHitSignal>(OnImpactHit);
		}

		public void Disable()
		{
			_entity.View.PhysicsCollider.Enabled = true;
			_signalBus.Unsubscribe<ImpactHitSignal>(OnImpactHit);
		}

		private void OnImpactHit(ImpactHitSignal args)
		{
			(var origin, var other) = args;
			if (origin != _entity)
			{
				return;
			}

			if (_impactEffect != null)
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
