using Greed.Core;
using Greed.UnityWrapper;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class EntityFacade : MonoBehaviour, IEntity
	{
		private IEntityView _view;

		public string Name => gameObject.name;

		[Inject]
		public void Construct(IEntityView view)
		{
			_view = view;
		}

		public void Place(Vector3 position) => _view.Place(position);
	}
}
