using Greed.UnityWrapper;

namespace Greed.Core
{
	public interface IEntity
	{
		string Name { get; }
		IEntityView View { get; }
		ITransform PickupSlot { get; }
	}
}
