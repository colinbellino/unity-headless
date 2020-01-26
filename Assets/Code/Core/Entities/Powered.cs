using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class Powered : MonoBehaviour, IInitializable, IDisposable, IPowered
	{
		private SignalBus _signalBus;
		private List<IPowerSource> _powerSources;
		private int _powerRequired = 1;

		private bool _isActive;

		[Inject]
		public void Construct(
			SignalBus signalBus,
			List<IPowerSource> powerSources
		)
		{
			_signalBus = signalBus;
			_powerSources = powerSources;

			if (powerSources.Count() > 0)
			{
				_powerRequired = _powerSources.Count();
			}
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
