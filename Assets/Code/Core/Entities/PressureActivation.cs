using System;
using System.Collections.Generic;
using Greed.UnityWrapper;
using Zenject;

namespace Greed.Core
{
	public class PressureActivation : IInitializable, IDisposable
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly string _colliderTag;
		private readonly int _requiredActivators = 1;

		private readonly List<IEntity> _activators = new List<IEntity>();
		private bool _activated = false;

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
			_entity.TriggerExited += TriggerExited;
		}

		public void Dispose()
		{
			_entity.TriggerEntered -= TriggerEntered;
			_entity.TriggerExited -= TriggerExited;
		}

		private void TriggerEntered(ICollider2D collider)
		{
			if (!collider.CompareTag(_colliderTag))
			{
				return;
			}

			var activator = collider.GameObject.GetComponentInParent<IEntity>();
			_activators.Add(activator);
			TrySendToggleSignal();
		}

		private void TriggerExited(ICollider2D collider)
		{
			if (!collider.CompareTag(_colliderTag))
			{
				return;
			}

			var activator = collider.GameObject.GetComponentInParent<IEntity>();
			_activators.Remove(activator);
			TrySendToggleSignal();
		}

		private void TrySendToggleSignal()
		{
			var activated = _activators.Count >= _requiredActivators;
			if (_activated != activated)
			{
				var signal = new ButtonToggledSignal { Target = _entity };
				_signalBus.Fire(signal);

				_activated = activated;
			}
		}
	}
}
