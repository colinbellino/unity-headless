using System;
using Greed.Core;
using Greed.UnityWrapper;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class EntityFacade : MonoBehaviour, IEntity
	{
		private IEntityView _view;
		private PickerHandler _pickerHandler;
		private IMoveDirection _moveHandler;

		public string Name => gameObject.name;
		public IEntityView View => _view;
		public ITransform PickupSlot => _pickerHandler.PickupSlot;
		public Vector3 MoveDirection => _moveHandler.MoveDirection;

		public Action<ICollider2D> TriggerEntered { get; set; } = delegate { };
		public Action<ICollider2D> TriggerExited { get; set; } = delegate { };

		[Inject]
		public void Construct(IEntityView view, PickerHandler pickerHandler, IMoveDirection moveHandler)
		{
			_view = view;
			_pickerHandler = pickerHandler;
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
