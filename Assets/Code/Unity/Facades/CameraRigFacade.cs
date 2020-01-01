using Greed.Core;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class CameraRigFacade : MonoBehaviour, ICameraRig
	{
		private CameraRig _rig;

		[Inject]
		public void Construct(CameraRig rig)
		{
			_rig = rig;
		}

		public void MoveCameraInDirection(Vector2Int direction)
		{
			_rig.MoveCameraInDirection(direction);
		}
	}

	// FIXME: Delete this once we have the room transitions working.
	[CustomEditor(typeof(CameraRigFacade))]
	public class CameraRigFacadeEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			CameraRigFacade rig = (CameraRigFacade) target;

			DrawDefaultInspector();

			GUI.enabled = EditorApplication.isPlaying;
			if (GUILayout.Button("left"))
			{
				rig.MoveCameraInDirection(new Vector2Int(-32, 0));
			}
			if (GUILayout.Button("right"))
			{
				rig.MoveCameraInDirection(new Vector2Int(32, 0));
			}
			// if (GUILayout.Button("Center to Player"))
			// {
			// 	var player = FindObjectOfType<Player>();
			// 	rig.MoveCameraInDirection(player.transform.position);
			// }
			GUI.enabled = true;
		}
	}
}
