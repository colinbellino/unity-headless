using System;
using Greed.UnityWrapper;
using Zenject;

namespace Greed.Core
{
	public class OrbitOnCollect : IInitializable, IDisposable
	{
		private readonly SignalBus _signalBus;
		private readonly OrbitAroundTarget _orbitHandler;
		private readonly ICollider2D _collectCollider;
		private readonly IEntity _entity;

		public OrbitOnCollect(SignalBus signalBus, OrbitAroundTarget orbitHandler, ICollider2D collectCollider, IEntity entity)
		{
			_signalBus = signalBus;
			_orbitHandler = orbitHandler;
			_collectCollider = collectCollider;
			_entity = entity;
		}

		public void Initialize()
		{
			_signalBus.Subscribe<CollectedSignal>(OnCollected);
		}

		public void Dispose()
		{
			_signalBus.Unsubscribe<CollectedSignal>(OnCollected);
		}

		public void OnCollected(CollectedSignal args)
		{
			if (args.Collectable != _entity)
			{
				return;
			}

			var view = args.Collector.View;
			_orbitHandler.Activate(view.Transform);
			_collectCollider.Enabled = false;
		}
	}
}
