using Greed.Core;
using Greed.Unity;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "New Project Settings", menuName = "Greed/Settings/Project Settings")]
public class ProjectSettingsInstaller : ScriptableObjectInstaller<ProjectSettingsInstaller>
{
	[SerializeField] private CameraRigFacade _cameraRigPrefab;
	[SerializeField] private EntityFacade _playerPrefab;

	public override void InstallBindings()
	{
		Container.BindInstance(_cameraRigPrefab);
		Container.BindInstance(_playerPrefab);
	}
}
