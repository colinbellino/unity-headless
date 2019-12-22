using Greed.UnityWrapper;

namespace Greed.Core
{
	public class CollisionHitSignal
	{
		public IEntity Origin;
		public ICollider2D Other;

		public void Deconstruct(out IEntity origin, out ICollider2D other)
		{
			origin = Origin;
			other = Other;
		}
	}
}
