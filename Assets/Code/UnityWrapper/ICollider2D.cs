using UnityEngine;

namespace Greed.UnityWrapper
{
	public interface ICollider2D
	{
		bool Enabled { get; set; }
		IGameObject GameObject { get; }

		Vector2 ClosestPoint(Vector2 position);
	}
}
