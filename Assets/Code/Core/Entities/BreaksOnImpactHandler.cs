using System;
using Greed.UnityWrapper;
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
		private readonly ICollider2D _impactCollider;

		public BreaksOnImpactHandler(
			SignalBus signalBus,
			IEntity entity,
			AudioPlayer audioPlayer,
			AudioClip breakClip,
			ICollider2D impactCollider
		)
		{
			_signalBus = signalBus;
			_entity = entity;
			_audioPlayer = audioPlayer;
			_breakClip = breakClip;
			_impactCollider = impactCollider;
		}

		public void Initialize()
		{
			_signalBus.Subscribe<ImpactHitSignal>(ImpactHit);
		}

		public void Dispose()
		{
			_signalBus.Unsubscribe<ImpactHitSignal>(ImpactHit);
		}

		private void ImpactHit(ImpactHitSignal args)
		{
			if (args.Other.Equals(_impactCollider) == false)
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
