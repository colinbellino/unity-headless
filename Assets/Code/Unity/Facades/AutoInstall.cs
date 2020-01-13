using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class AutoInstall : MonoBehaviour
	{
		public void Awake()
		{
			var sceneContext = FindObjectOfType<SceneContext>();
			var context = GetComponent<GameObjectContext>();
			context.Install(sceneContext.Container);
			context.Run();
		}
	}
}
