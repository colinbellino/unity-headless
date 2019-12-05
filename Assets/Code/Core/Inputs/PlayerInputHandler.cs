using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class PlayerInputHandler : IInitializable, ITickable
	{
		private readonly EntityInputState _inputState;
		private readonly PlayerActions _actions;

		public PlayerInputHandler(EntityInputState inputState, PlayerActions actions)
		{
			_inputState = inputState;
			_actions = actions;
		}

		public void Initialize()
		{
			_actions.Enable();
		}

		public void Tick()
		{
			_inputState.Move = _actions.Default.Move.ReadValue<Vector2>();
		}
	}
}
