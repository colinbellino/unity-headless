using Greed.Unity;
using UnityEngine;
using Zenject;

public class GameSettingsInstaller : MonoInstaller<GameSettingsInstaller>
{
	[SerializeField] private CameraRigFacade _cameraRigPrefab;
	[SerializeField] private EntityFacade _playerPrefab;
	[SerializeField] private MainMenuFacade _mainMenuPrefab;

	public override void InstallBindings()
	{
		Container.BindInstance(_cameraRigPrefab);
		Container.BindInstance(_playerPrefab);
		Container.BindInstance(_mainMenuPrefab);
	}
}
