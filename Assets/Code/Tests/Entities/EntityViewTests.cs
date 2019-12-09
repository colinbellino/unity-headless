using Greed.Core;
using Greed.UnityWrapper;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Greed.Tests
{
	public class EntityViewTests
	{
		private EntityView _view;

		private IRigidbody2D _rigidbody;
		private ITransform _transform;
		private IAnimator _animator;
		private ICollider2D _physicsCollider;

		[SetUp]
		public void SetUp()
		{
			_rigidbody = Substitute.For<IRigidbody2D>();
			_transform = Substitute.For<ITransform>();
			_animator = Substitute.For<IAnimator>();
			_physicsCollider = Substitute.For<ICollider2D>();

			_view = new EntityView(_rigidbody, _transform, _animator, _physicsCollider);

			ThenHasPosition(Vector3.zero);
		}

		[Test]
		public void MovePosition_CallsMovePositionToDestination()
		{
			_view.MovePosition(Vector3.right);
			ThenCallsMovePosition(Vector3.right);
		}

		[Test]
		public void Place_SetsPositionToDestination()
		{
			_view.Place(Vector3.right);
			ThenHasPosition(Vector3.right);
		}

		[Test]
		public void PlayAnimation_CallsPlayAndWait()
		{
			Assert.Fail("Not tested yet.");
		}

		[Test]
		public void AttachTo_AttachsToTarget()
		{
			Assert.Fail("Not tested yet.");
		}

		private void ThenCallsMovePosition(Vector3 position)
		{
			_rigidbody.Received().MovePosition(position);
		}

		private void ThenHasPosition(Vector3 position)
		{
			Assert.AreEqual(_view.Position, position);
		}
	}
}
