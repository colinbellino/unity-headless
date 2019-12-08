using UnityEngine;

namespace Greed.Core
{
	public class InteractiveObjectFinder
	{
		public IEntity GetClosest(Vector2 origin)
		{
			var radius = 1f;
			var direction = Vector2.zero;
			var distance = 1f;
			var layerMask = LayerMask.GetMask("Interactive");

			// TODO: Draw this
			var hits = Physics2D.CircleCastAll(origin, radius, direction, distance, layerMask);
			foreach (var hit in hits)
			{
				return hit.collider.GetComponentInParent<IEntity>();
			}

			return null;
		}
	}
}
