using Greed.Core;
using Greed.UnityWrapper;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class EntityFacade : MonoBehaviour, IEntity
	{
		private PickerHandler _pickerHandler;

		public IEntityView View { get; private set; }
		public ITransform PickupSlot => _pickerHandler.PickupSlot;
		public string Name => gameObject.name;

		[Inject]
		public void Construct(IEntityView view, PickerHandler pickerHandler)
		{
			View = view;
			_pickerHandler = pickerHandler;
		}

		public void Place(Vector3 position) => View.Place(position);
	}
}
