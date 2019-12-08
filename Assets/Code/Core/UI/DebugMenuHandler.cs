using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Greed.Core
{
	public class DebugMenuHandler : IInitializable, IDisposable
	{
		private readonly PlayerActions _actions;

		public DebugMenuHandler(PlayerActions actions)
		{
			_actions = actions;
		}

		public void Initialize()
		{
			_actions.Debug.Enable();
			_actions.Debug.ToggleMenu.performed += OnToggleMenuPerformed;
		}

		public void Dispose()
		{
			_actions.Debug.Disable();
			_actions.Debug.ToggleMenu.performed -= OnToggleMenuPerformed;
		}

		private void OnToggleMenuPerformed(InputAction.CallbackContext context)
		{
			if (SRDebug.Instance.IsDebugPanelVisible)
			{
				SRDebug.Instance.HideDebugPanel();
			}
			else
			{
				SRDebug.Instance.ShowDebugPanel();
			}
		}
	}
}
