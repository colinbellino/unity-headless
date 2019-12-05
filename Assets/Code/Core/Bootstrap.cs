using Zenject;

namespace Greed.Core
{
	public class Bootstrap : IInitializable
	{
		private readonly ICameraRig _cameraRig;

		public Bootstrap(ICameraRig cameraRig)
		{
			_cameraRig = cameraRig;
		}

		public void Initialize()
		{
			UnityEngine.Debug.Log(_cameraRig);
		}
	}
}
