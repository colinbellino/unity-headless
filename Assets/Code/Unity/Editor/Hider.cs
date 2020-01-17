using UnityEditor;
using UnityEngine;

namespace Greed.Unity.Editor
{
	// Source: https://answers.unity.com/questions/613728/how-do-i-remove-a-game-object-that-is-not-visible.html
	public class Hider : EditorWindow
	{
		[MenuItem("Tools/Hider")]
		public static void Create()
		{
			var window = GetWindow<Hider>();
			window.titleContent = new GUIContent("Hidden GOs");
		}

		public void OnGUI()
		{
			if (GUILayout.Button("Log flags"))
			{
				Debug.Log(Selection.activeGameObject.hideFlags);
			}

			if (GUILayout.Button("Remove flags"))
			{
				Selection.activeGameObject.hideFlags = HideFlags.None;
			}

			if (GUILayout.Button("Create hidden GO"))
			{
				GameObject h = new GameObject("hidden");
				h.hideFlags = HideFlags.HideInHierarchy;
			}

			if (GUILayout.Button("Select hidden GO"))
			{
				Selection.activeGameObject = GameObject.Find("hidden");
			}

			if (GUILayout.Button("Destroy selected GO"))
			{
				DestroyImmediate(Selection.activeObject);
			}
		}
	}
}
