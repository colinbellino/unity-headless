using UnityEngine;

namespace Greed.Unity
{
	public class DisableRPDebugger : MonoBehaviour
	{
		public void Start()
		{
			var updater = GameObject.Find("[Debug Updater]");
			updater?.SetActive(false);
		}
	}
}
