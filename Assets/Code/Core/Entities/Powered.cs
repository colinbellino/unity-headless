using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Greed.Core
{
	public class Powered : IInitializable, IDisposable, IPowered
	{
		private readonly SignalBus _signalBus;
		private readonly List<IPowerSource> _powerSources;
		private readonly int _powerRequired = 1;

		private bool _isActive;

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
			var isActive = _powerSources.Where(source => source.IsActive).Count() >= _powerRequired;
			if (_isActive != isActive)
			{
				var signal = new PoweredToggledSignal { Powered = this, IsActive = isActive };
				_signalBus.Fire(signal);
				_isActive = isActive;
			}
		}
	}
}
