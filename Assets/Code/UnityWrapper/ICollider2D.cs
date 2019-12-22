using UnityEngine;

namespace Greed.UnityWrapper
{
	public interface ICollider2D
	{
		bool Enabled { get; set; }
		bool IsTrigger { get; }
		IGameObject GameObject { get; }

		Vector2 ClosestPoint(Vector2 position);
	}
}
