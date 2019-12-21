using UnityEngine;

namespace Greed.UnityWrapper
{
	public class UnityRaycastHit2D : IRaycastHit2D
	{
		private RaycastHit2D _hit;

		public Vector2 Point => _hit.point;

		public UnityRaycastHit2D(RaycastHit2D hit)
		{
			_hit = hit;
		}
	}
}
