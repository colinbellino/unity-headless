using Greed.Core;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class EntityFacade : MonoBehaviour, IEntity
	{
		private IEntityView _view;

		[Inject]
		public void Construct(IEntityView view)
		{
			_view = view;
		}

		public void Place(Vector3 position) => _view.Place(position);
	}
}
