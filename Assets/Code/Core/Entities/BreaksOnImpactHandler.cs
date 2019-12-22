using System;
using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class BreaksOnImpactHandler : IInitializable, IDisposable
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly AudioPlayer _audioPlayer;
		private readonly AudioClip _breakClip;

		public BreaksOnImpactHandler(
			SignalBus signalBus,
			IEntity entity,
			AudioPlayer audioPlayer,
			AudioClip breakClip
		)
		{
			_signalBus = signalBus;
			_entity = entity;
			_audioPlayer = audioPlayer;
			_breakClip = breakClip;
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
			(var origin, var other) = args;

			var wasPhysicsCollider = other.Equals(_entity.View.PhysicsCollider);
			if (!wasPhysicsCollider)
			{
				return;
			}

			_entity.View.SetAnimationTrigger("Break");
			// TODO: Spawn the shards

			if (_breakClip)
			{
				_audioPlayer.PlayOneShot(_breakClip);
			}
		}
	}
}
