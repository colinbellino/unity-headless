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

		public ICollider2D PhysicsCollider => _physicsCollider;
		public Vector3 Position => _transform.Position;
		public ITransform Transform => _transform;

		public Vector3 LocalPosition
		{
			get => _transform.LocalPosition;
			set => _transform.LocalPosition = value;
		}

		public Vector2 Velocity
		{
			get => _rigidbody.Velocity;
			set => _rigidbody.Velocity = value;
		}

		public void MovePosition(Vector3 destination) => _rigidbody.MovePosition(destination);

		public void Place(Vector3 destination) => _transform.Position = destination;

		public void AttachTo(ITransform target)
		{
			_transform.Parent = target;
			_transform.LocalPosition = Vector3.zero;
			_rigidbody.BodyType = RigidbodyType2D.Kinematic;
			_physicsCollider.Enabled = false;
		}

		public void Detach()
		{
			_transform.Parent = null;
			_rigidbody.BodyType = RigidbodyType2D.Dynamic;
			_physicsCollider.Enabled = true;
		}

		public void AddForce(Vector2 force, ForceMode2D mode = ForceMode2D.Force)
		{
			_rigidbody.AddForce(force, mode);
		}

		public UniTask PlayAnimation(string stateName, int layer = 0, float normalizedTime = float.NegativeInfinity)
		{
			_animator.Play(stateName, layer, normalizedTime);
			return UniTask.WaitWhile(() => _animator.GetCurrentAnimatorStateInfo(layer).IsName(stateName));
		}

		public void SetAnimationFloat(string name, float value) => _animator.SetFloat(name, value);

		public void SetAnimationTrigger(string name) => _animator.SetTrigger(name);
	}
}
