using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Greed.Core
{
	public class Powered : IInitializable, IDisposable
	{
		private readonly SignalBus _signalBus;
		private readonly List<IPowerSource> _powerSources;
		private readonly int _powerRequired = 1;

		public Powered(
			SignalBus signalBus,
			List<IPowerSource> powerSources
		)
		{
			_signalBus = signalBus;
			_powerSources = powerSources;

			_powerRequired = _powerSources.Count();
		}

		public void Initialize()
		{
			_signalBus.Subscribe<PowerSourceToggledSignal>(OnPowerSourceActivated);
		}

		public void Dispose()
		{
			_signalBus.Unsubscribe<PowerSourceToggledSignal>(OnPowerSourceActivated);
		}

		private void OnPowerSourceActivated()
		{
			var isPowered = _powerSources.Where(source => source.IsActive).Count() >= _powerRequired;
			UnityEngine.Debug.Log($"is powered ? {isPowered}");
		}
	}
}
