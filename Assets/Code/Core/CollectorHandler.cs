using System;
using Greed.UnityWrapper;
using Zenject;

namespace Greed.Core
{
	public class CollectorHandler : IInitializable, IDisposable
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly string _collectColliderTag;

		public CollectorHandler(SignalBus signalBus, IEntity entity, string collectColliderTag)
		{
			_signalBus = signalBus;
			_entity = entity;
			_collectColliderTag = collectColliderTag;
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
			if (collider.CompareTag(_collectColliderTag))
			{
				var collectable = collider.GameObject.GetComponentInParent<IEntity>();
				var signal = new CollectedSignal { Collector = _entity, Collectable = collectable };
				_signalBus.Fire(signal);
			}
		}
	}
}
