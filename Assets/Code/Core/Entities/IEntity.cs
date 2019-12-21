using System;
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

		Action<ICollider2D> TriggerEntered { get; set; }
		Action<ICollider2D> TriggerExited { get; set; }
	}
}
