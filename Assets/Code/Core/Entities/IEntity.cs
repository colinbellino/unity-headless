using System;
using Greed.UnityWrapper;
using UnityEngine;

namespace Greed.Core
{
	public interface IEntity
	{
		string Name { get; }
		IEntityView View { get; }

		Action<ICollider2D> TriggerEntered { get; set; }
		Action<ICollider2D> TriggerExited { get; set; }

		// TODO: Find a better way to store this.
		Vector3 MoveDirection { get; set; }
		IEntity CurrentPickup { get; set; }
		ITransform PickupSlot { get; }
	}
}
