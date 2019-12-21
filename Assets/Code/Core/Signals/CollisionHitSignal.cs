using Greed.UnityWrapper;

namespace Greed.Core
{
	public class CollisionHitSignal
	{
		public IEntity Origin;
		public ICollider2D Collider;

		public void Deconstruct(out IEntity origin, out ICollider2D collider)
		{
			origin = Origin;
			collider = Collider;
		}
	}
}
