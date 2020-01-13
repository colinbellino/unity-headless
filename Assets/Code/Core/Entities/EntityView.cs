using System.Collections;
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

		public void AttachTo(ITransform target, bool resetLocalPosition = true)
		{
			_transform.Parent = target;
			_rigidbody.BodyType = RigidbodyType2D.Kinematic;
			_physicsCollider.Enabled = false;

			if (resetLocalPosition)
			{
				_transform.LocalPosition = Vector3.zero;
			}
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

		public void MoveTowards(Vector3 destination, float step)
		{
			_transform.Position = Vector3.MoveTowards(_transform.Position, destination, step);
		}

		public IEnumerator MoveToPosition(Vector3 position, float durationInSeconds)
		{
			var currentPosition = _transform.Position;
			var currentTime = 0f;
			while (currentTime < 1f)
			{
				currentTime += Time.deltaTime / durationInSeconds;
				_transform.Position = Vector3.Lerp(currentPosition, position, currentTime);
				yield return null;
			}
		}

		public void RotateAround(Vector3 target, Vector3 axis, float angle)
		{
			_transform.RotateAround(target, axis, angle);
		}

		public UniTask PlayAnimationTask(string stateName, int layer = 0, float normalizedTime = float.NegativeInfinity)
		{
			_animator.Play(stateName, layer, normalizedTime);
			return UniTask.WaitWhile(() => _animator.GetCurrentAnimatorStateInfo(layer).IsName(stateName));
		}

		public void PlayAnimation(string stateName, int layer = 0, float normalizedTime = float.NegativeInfinity)
		{
			_animator.Play(stateName, layer, normalizedTime);
			_animator.GetCurrentAnimatorStateInfo(layer).IsName(stateName);
		}

		public void SetAnimationFloat(string name, float value) => _animator?.SetFloat(name, value);

		public void SetAnimationTrigger(string name) => _animator?.SetTrigger(name);
	}
}
