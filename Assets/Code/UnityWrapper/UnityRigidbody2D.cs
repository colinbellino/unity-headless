using UnityEngine;

namespace Greed.UnityWrapper
{
	public class UnityRigidbody2D : IRigidbody2D
	{
		private readonly Rigidbody2D _rigidbody;

		public UnityRigidbody2D(Rigidbody2D rigidbody)
		{
			_rigidbody = rigidbody;
		}

		public void MovePosition(Vector3 position)
		{
			_rigidbody.MovePosition(position);
		}
	}
}
