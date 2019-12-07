using Zenject;

namespace Greed.Core
{
	public class Bootstrap : IInitializable
	{
		private readonly ICameraRig _cameraRig;
		private readonly IEntity _player;
		private readonly IMainMenu _mainMenu;

		public Bootstrap(ICameraRig cameraRig, IEntity player, IMainMenu mainMenu)
		{
			_cameraRig = cameraRig;
			_player = player;
			_mainMenu = mainMenu;
		}

		public void Initialize()
		{
			// TODO: Position the player.
			// TODO: Position the camera rig.

			_mainMenu.Show();
		}
	}
}
