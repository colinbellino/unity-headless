using System;
using Greed.UnityWrapper;
using Zenject;

namespace Greed.Core
{
	public class PickupImpact : IInitializable, IDisposable
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly string _impactColliderTag;

		public PickupImpact(SignalBus signalBus, IEntity entity, string impactColliderTag)
		{
			_signalBus = signalBus;
			_entity = entity;
			_impactColliderTag = impactColliderTag;
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
			if (collider.CompareTag(_impactColliderTag) || collider.GameObject.IsStatic)
			{
				var signal = new ImpactHitSignal { Origin = _entity, Other = collider };
				_signalBus.Fire(signal);
			}
		}
	}
}
