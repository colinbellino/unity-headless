using System;
using UnityEngine.VFX;
using Zenject;

namespace Greed.Core
{
	public class ImpactHandler : IInitializable, IDisposable
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly EffectsManager _effectsManager;
		private readonly VisualEffect _impactEffect;

		public ImpactHandler(
			SignalBus signalBus,
			IEntity entity,
			EffectsManager effectsManager,
			VisualEffect impactEffect
		)
		{
			_signalBus = signalBus;
			_entity = entity;
			_effectsManager = effectsManager;
			_impactEffect = impactEffect;
		}

		public void Initialize()
		{
			// _signalBus.Subscribe<ThrowStartedSignal>(ThrowStarted);
		}

		public void Dispose()
		{
			// _signalBus.Unsubscribe<ThrowStartedSignal>(ThrowStarted);
		}

		// TODO: check for collision and trigger this on hit with a wall
		private void ThrowStarted(ThrowStartedSignal args)
		{
			if (args.Target != _entity)
			{
				return;
			}

			_effectsManager.Spawn(_impactEffect);
		}
	}
}
