using Greed.UnityWrapper;
using UnityEngine;

namespace Greed.Core
{
	public interface IEntity
	{
		string Name { get; }
		IEntityView View { get; }
		ITransform PickupSlot { get; }
		Vector3 MoveDirection { get; }
	}
}
