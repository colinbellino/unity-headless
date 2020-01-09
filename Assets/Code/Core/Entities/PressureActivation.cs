using System;
using System.Collections.Generic;
using Greed.UnityWrapper;
using Zenject;

namespace Greed.Core
{
	public class PressureActivation : IInitializable, IDisposable, IActivable
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly IPowerSource _powerSource;
		private readonly string _colliderTag;
		private readonly int _requiredActivators = 1;

		public bool IsActive { get; private set; }

		private readonly List<IEntity> _activators = new List<IEntity>();

		public PressureActivation(
			SignalBus signalBus,
			IEntity entity,
			IPowerSource powerSource,
			string colliderTag
		)
		{
			_signalBus = signalBus;
			_entity = entity;
			_powerSource = powerSource;
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
			var newIsActive = _activators.Count >= _requiredActivators;
			if (IsActive != newIsActive)
			{
				IsActive = newIsActive;
				var signal = new PowerSourceToggledSignal { Source = _powerSource, IsActive = newIsActive };
				_signalBus.Fire(signal);
			}
		}
	}

	public interface IActivable
	{
		bool IsActive { get; }
	}
}
