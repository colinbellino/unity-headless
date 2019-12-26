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
		private IMoveDirection _moveHandler;

		public string Name => gameObject.name;
		public IEntityView View { get; private set; }
		public Vector3 MoveDirection => _moveHandler.MoveDirection;

		public Action<ICollider2D> TriggerEntered { get; set; } = delegate { };
		public Action<ICollider2D> TriggerExited { get; set; } = delegate { };

		[Inject]
		public void Construct(IEntityView view, IMoveDirection moveHandler)
		{
			View = view;
			_moveHandler = moveHandler;
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
