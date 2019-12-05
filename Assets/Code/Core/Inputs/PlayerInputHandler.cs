using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class PlayerInputHandler : ITickable
	{
		private readonly EntityInputState _inputState;

		public PlayerInputHandler(EntityInputState inputState)
		{
			_inputState = inputState;
		}

		public void Tick()
		{
			_inputState.Move = new Vector2(0.5f, 0.5f);
		}
	}
}
