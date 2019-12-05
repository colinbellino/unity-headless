using Zenject;

namespace Greed.Core
{
	public class Bootstrap : IInitializable
	{
		private readonly ICameraRig _cameraRig;
		private readonly IEntity _player;

		public Bootstrap(ICameraRig cameraRig, IEntity player)
		{
			_cameraRig = cameraRig;
			_player = player;
		}

		public void Initialize()
		{
			UnityEngine.Debug.Log("_cameraRig => " + _cameraRig);
			UnityEngine.Debug.Log("_player => " + _player);
		}
	}
}
