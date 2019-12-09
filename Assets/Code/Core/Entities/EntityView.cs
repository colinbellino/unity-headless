using Greed.UnityWrapper;
using UniRx.Async;
using UnityEngine;

namespace Greed.Core
{
	public class EntityView : IEntityView
	{
		private readonly IRigidbody2D _rigidbody;
		private readonly ITransform _transform;
		private readonly IAnimator _animator;
		private readonly ICollider2D _physicsCollider;

		public EntityView(
			IRigidbody2D rigidbody,
			ITransform transform,
			IAnimator animator,
			ICollider2D physicsCollider
		)
		{
			_rigidbody = rigidbody;
			_transform = transform;
			_animator = animator;
			_physicsCollider = physicsCollider;
		}

		public Vector3 Position => _transform.Position;

		public ITransform Transform => _transform;

		public Vector3 LocalPosition
		{
			get => _transform.LocalPosition;
			set => _transform.LocalPosition = value;
		}

		public void MovePosition(Vector3 destination) => _rigidbody.MovePosition(destination);

		public void Place(Vector3 destination) => _transform.Position = destination;

		public void AttachTo(IEntity target)
		{
			_transform.Parent = target.View.Transform;
			_rigidbody.BodyType = RigidbodyType2D.Kinematic;
			_physicsCollider.Enabled = false;
		}

		public UniTask PlayAnimation(string stateName, int layer = -1, float normalizedTime = float.NegativeInfinity)
		{
			_animator.Play(stateName, layer, normalizedTime);

			// FIXME: Actually wait for the animation to be over.
			return UniTask.Delay(System.TimeSpan.FromMilliseconds(300));
		}
	}
}
