using System;
using Greed.Core;
using Greed.UnityWrapper;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	[SelectionBase]
	public class EntityFacade : MonoBehaviour, IEntity
	{
		public string Name => gameObject.name;
		public IEntityView View { get; private set; }

		public Action<ICollider2D> TriggerEntered { get; set; } = delegate { };
		public Action<ICollider2D> TriggerExited { get; set; } = delegate { };

		public Vector3 MoveDirection { get; set; }
		public IEntity CurrentPickup { get; set; }
		public ITransform PickupSlot { get; private set; }

		[Inject]
		public void Construct(IEntityView view, ITransform pickupSlot)
		{
			View = view;
			PickupSlot = pickupSlot;
		}

		public void Place(Vector3 position) => View.Place(position);

		public void OnTriggerEnter2D(Collider2D collider)
		{
			TriggerEntered(Wrappers.Wrap(collider));
		}

		public void OnTriggerExit2D(Collider2D collider)
		{
			TriggerExited(Wrappers.Wrap(collider));
		}
	}
}
