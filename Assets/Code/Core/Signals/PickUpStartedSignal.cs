using Greed.UnityWrapper;

namespace Greed.Core
{
	public class PickUpStartedSignal
	{
		public IEntity Picker;
		public IEntity Target;
		public ITransform Slot;
	}
}
