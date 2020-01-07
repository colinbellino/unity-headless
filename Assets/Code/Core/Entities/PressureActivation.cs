using System;
using Greed.UnityWrapper;
using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class PressureActivation : IInitializable, IDisposable
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly AudioPlayer _audioPlayer;
		private readonly AudioClip _activateClip;
		private readonly AudioClip _deactivateClip;
		private readonly string _colliderTag;

		public PressureActivation(
			SignalBus signalBus,
			IEntity entity,
			AudioPlayer audioPlayer,
			AudioClip activateClip,
			AudioClip deactivateClip,
			string colliderTag
		)
		{
			_signalBus = signalBus;
			_entity = entity;
			_audioPlayer = audioPlayer;
			_activateClip = activateClip;
			_deactivateClip = deactivateClip;
			_colliderTag = colliderTag;
		}

		public void Initialize()
		{
			_entity.TriggerEntered += TriggerEntered;
		}

		public void Dispose()
		{
			_entity.TriggerEntered -= TriggerEntered;
		}

		private void TriggerEntered(ICollider2D collider)
		{
			if (!collider.CompareTag(_colliderTag))
			{
				return;
			}

			var activator = collider.GameObject.GetComponent<IEntity>();
			var signal = new ButtonToggledSignal { Target = _entity, Activator = activator };
			_signalBus.Fire(signal);

			// if (_activateClip)
			// {
			// 	_audioPlayer.PlayOneShot(_activateClip);
			// }
		}
	}
}
