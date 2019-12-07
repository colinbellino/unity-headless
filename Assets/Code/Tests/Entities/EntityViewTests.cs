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

		[SetUp]
		public void SetUp()
		{
			_rigidbody = Substitute.For<IRigidbody2D>();
			_transform = Substitute.For<ITransform>();

			_view = new EntityView(_rigidbody, _transform);

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
