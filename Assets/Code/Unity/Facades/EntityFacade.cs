using Greed.Core;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class EntityFacade : MonoBehaviour, IEntity
	{
		public string Name => gameObject.name;
		public IEntityView View { get; private set; }

		[Inject]
		public void Construct(IEntityView view)
		{
			View = view;
		}

		public void Place(Vector3 position) => View.Place(position);
	}
}
