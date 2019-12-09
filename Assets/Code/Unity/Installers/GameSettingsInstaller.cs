using System.Collections.Generic;
using Greed.Unity;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class GameSettingsInstaller : MonoInstaller
{
	[SerializeField] private CameraRigFacade _cameraRigPrefab;
	[SerializeField] private EntityFacade _playerPrefab;
	[SerializeField] private List<AssetReference> _loadedScenes;

	public override void InstallBindings()
	{
		Container.BindInstance(_cameraRigPrefab);
		Container.BindInstance(_playerPrefab);
		Container.BindInstance(_loadedScenes);
	}
}
