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

		public IEntityView View => _view;
		public ITransform PickupSlot => _pickerHandler.PickupSlot;
		public string Name => gameObject.name;

		public Vector3 MoveDirection => _moveHandler.MoveDirection;

		[Inject]
		public void Construct(IEntityView view, PickerHandler pickerHandler, IMoveDirection moveHandler)
		{
			_view = view;
			_pickerHandler = pickerHandler;
			_moveHandler = moveHandler;
		}

		public void Place(Vector3 position) => View.Place(position);
	}
}
