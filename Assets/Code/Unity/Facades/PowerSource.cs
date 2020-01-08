using Greed.Core;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class PowerSource : MonoBehaviour, IPowerSource
	{
		private IActivable _activable;

		public bool IsActive => _activable.IsActive;

		[Inject]
		public void Construct(IActivable activable)
		{
			_activable = activable;
		}
	}
}
