using Greed.Core;
using Greed.UnityWrapper;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Greed.Tests
{
	public class EntityMoveHandlerTests
	{
		private EntityMoveHandler _handler;

		private EntityInputState _inputState;
		private IEntityView _view;
		private ITime _time;
		private int _speed;

		[SetUp]
		public void SetUp()
		{
			_inputState = new EntityInputState();
			_view = Substitute.For<IEntityView>();
			_time = Substitute.For<ITime>();

			WhenMoveInput(Vector3.right);
			WhenFixedDeltaTime(1f);
			WhenSpeed(1);
		}

		[Test]
		public void WhenMoveInputEast_DoesMovePositionTo1x0()
		{
			FixedTick();
			ThenMovePosition(Vector3.right);
		}

		[Test]
		public void WhenNormalNorth_DoesMovePosition0x1()
		{
			WhenMoveInput(Vector3.up);
			FixedTick();
			ThenMovePosition(Vector3.up);
		}

		[Test]
		public void WhenSpeedIs0_DoesntMovePosition()
		{
			WhenSpeed(0);
			FixedTick();
			ThenMovePosition(Vector3.zero);
		}

		[Test]
		public void WhenMoveIs0_DoesntMovePosition()
		{
			WhenMoveInput(Vector3.zero);
			FixedTick();
			ThenMovePosition(Vector3.zero);
		}

		[Test]
		public void WhenFixedDeltaTimeIs0_DoesntMovePosition()
		{
			WhenFixedDeltaTime(0f);
			FixedTick();
			ThenMovePosition(Vector3.zero);
		}

		private void WhenSpeed(int value)
		{
			_speed = value;
		}

		private void WhenMoveInput(Vector3 value)
		{
			_inputState.Move = value;
		}

		private void WhenFixedDeltaTime(float value)
		{
			_time.FixedDeltaTime.Returns(value);
		}

		private void FixedTick()
		{
			_handler = new EntityMoveHandler(_inputState, _view, _time, _speed);
			_handler.FixedTick();
		}

		private void ThenMovePosition(Vector3 position)
		{
			_view.Received().MovePosition(position);
		}
	}
}
