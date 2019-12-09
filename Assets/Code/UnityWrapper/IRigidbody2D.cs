using UnityEngine;

namespace Greed.UnityWrapper
{
	public interface IRigidbody2D
	{
		void MovePosition(Vector3 position);
		RigidbodyType2D BodyType { get; set; }
	}
}
