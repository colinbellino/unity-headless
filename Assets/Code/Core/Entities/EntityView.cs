using Greed.UnityWrapper;
using UnityEngine;

namespace Greed.Core
{
	public class EntityView : IEntityView
	{
		private readonly IRigidbody2D _rigidbody;
		private readonly ITransform _transform;

		public EntityView(IRigidbody2D rigidbody, ITransform transform)
		{
			_rigidbody = rigidbody;
			_transform = transform;
		}

		public Vector3 Position => _transform.Position;

		public void MovePosition(Vector3 position)
		{
			_rigidbody.MovePosition(position);
		}
	}
}
