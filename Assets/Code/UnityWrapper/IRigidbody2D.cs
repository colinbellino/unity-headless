using UnityEngine;

namespace Greed.UnityWrapper
{
	public interface IRigidbody2D
	{
		void MovePosition(Vector3 position);
		RigidbodyType2D BodyType { get; set; }
		Vector2 Velocity { get; set; }

		void AddForce(Vector2 force, ForceMode2D mode = ForceMode2D.Force);
	}
}
