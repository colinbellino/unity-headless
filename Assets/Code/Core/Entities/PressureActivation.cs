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
		private readonly string _colliderTag;

		public PressureActivation(
			SignalBus signalBus,
			IEntity entity,
			string colliderTag
		)
		{
			_signalBus = signalBus;
			_entity = entity;
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
		}
	}
}
