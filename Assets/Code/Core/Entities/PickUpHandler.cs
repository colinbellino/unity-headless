using System;
using Zenject;

namespace Greed.Core
{
	public class PickUpHandler : IInitializable, IDisposable
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;

		public PickUpHandler(SignalBus signalBus, IEntity entity)
		{
			_signalBus = signalBus;
			_entity = entity;
		}

		public void Initialize()
		{
			_signalBus.Subscribe<PickUpEndedSignal>(PickUpEnded);
		}

		public void Dispose()
		{
			_signalBus.Unsubscribe<PickUpEndedSignal>(PickUpEnded);
		}

		private void PickUpEnded(PickUpEndedSignal args)
		{
			if (args.Target == _entity)
			{
				// TODO: Attach the entity to the actor.
				UnityEngine.Debug.Log($"{args.Target.Name} picked up {args.Actor.Name}.");
			}
		}
	}
}
