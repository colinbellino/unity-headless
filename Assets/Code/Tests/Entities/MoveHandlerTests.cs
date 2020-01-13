using Greed.Core;
using Greed.UnityWrapper;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Greed.Tests
{
	public class MoveHandlerTests
	{
		private MoveHandler _handler;

		private IEntityView _view;
		private ITime _time;
		private int _speed;

		[SetUp]
		public void SetUp()
		{
			_view = Substitute.For<IEntityView>();
			_time = Substitute.For<ITime>();

			WhenFixedDeltaTime(1f);
			WhenSpeed(1);
		}

		[Test]
		public void WhenMoveInputIsRight_DoesMovePositionTo1x0()
		{
			Move(Vector3.right);
			ThenMovePositionWasCalled(Vector3.right);
		}

		[Test]
		public void WhenMoveInputIsUp_DoesMovePosition0x1()
		{
			Move(Vector3.up);
			ThenMovePositionWasCalled(Vector3.up);
		}

		[Test]
		public void WhenMoveInputIs0_DoesntMovePosition()
		{
			Move(Vector3.zero);
			ThenMovePositionWasCalled(Vector3.zero);
		}

		[Test]
		public void WhenSpeedIs0_DoesntMovePosition()
		{
			WhenSpeed(0);
			Move(Vector3.right);
			ThenMovePositionWasCalled(Vector3.zero);
		}

		[Test]
		public void WhenFixedDeltaTimeIs0_DoesntMovePosition()
		{
			WhenFixedDeltaTime(0f);
			Move(Vector3.right);
			ThenMovePositionWasCalled(Vector3.zero);
		}

		private void WhenSpeed(int value)
		{
			_speed = value;
		}

		private void WhenFixedDeltaTime(float value)
		{
			_time.FixedDeltaTime.Returns(value);
		}

		private void Move(Vector3 position)
		{
			_handler = new MoveHandler(_view, _time, _speed);
			_handler.Move(position);
		}

		private void ThenMovePositionWasCalled(Vector3 position)
		{
			_view.Received().MovePosition(position);
		}
	}
}
