using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Greed.Core
{
	public class Powered : ITickable
	{
		private readonly List<IPowerSource> _powerSources;
		private readonly int _powerRequired = 1;

		public Powered(
			List<IPowerSource> powerSources
		)
		{
			_powerSources = powerSources;

			_powerRequired = _powerSources.Count();
		}

		public void Tick()
		{
			// FIXME: Maybe don't do this every tick ?
			var isPowered = _powerSources.Where(source => source.IsActive).Count() >= _powerRequired;
			UnityEngine.Debug.Log($"is powered ? {isPowered}");
		}
	}
}
