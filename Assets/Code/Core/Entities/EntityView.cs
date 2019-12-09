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

		public EntityView(IRigidbody2D rigidbody, ITransform transform, IAnimator animator)
		{
			_rigidbody = rigidbody;
			_transform = transform;
			_animator = animator;
		}

		public Vector3 Position => _transform.Position;

		public void MovePosition(Vector3 destination) => _rigidbody.MovePosition(destination);

		public void Place(Vector3 destination) => _transform.Position = destination;

		public UniTask PlayAnimation(string stateName, int layer = -1, float normalizedTime = float.NegativeInfinity)
		{
			_animator.Play(stateName, layer, normalizedTime);

			// FIXME: Actually wait for the animation to be over.
			return UniTask.Delay(System.TimeSpan.FromMilliseconds(300));
		}
	}
}
