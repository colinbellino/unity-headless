using System;
using Greed.UnityWrapper;
using Zenject;

namespace Greed.Core
{
	public class FallHandler : IInitializable, IDisposable
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly string _fallColliderTag;

		public FallHandler(SignalBus signalBus, IEntity entity, string collectColliderTag)
		{
			_signalBus = signalBus;
			_entity = entity;
			_fallColliderTag = collectColliderTag;
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
			if (collider.CompareTag(_fallColliderTag))
			{
				var target = collider.GameObject.GetComponentInParent<IEntity>();
				var signal = new FellSignal { Hole = _entity, Target = target };
				_signalBus.Fire(signal);
			}
		}
	}
}
