using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class AutoInstall : MonoBehaviour
	{
		public void Awake()
		{

		}

		public void Start()
		{
			var levelInstaller = FindObjectOfType<LevelInstaller>();
			var sceneContext = levelInstaller.GetComponent<SceneContext>();
			var context = GetComponent<GameObjectContext>();

			context.Install(sceneContext.Container);
			context.Run();
		}
	}
}
