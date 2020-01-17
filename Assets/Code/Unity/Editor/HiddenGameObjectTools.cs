using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Greed.Unity.Editor
{
	// Source: https://answers.unity.com/questions/613728/how-do-i-remove-a-game-object-that-is-not-visible.html
	public class HiddenGameObjectTools : EditorWindow
	{
		#region Menu Command

		[MenuItem("Tools/Hidden GameObject Tools")]
		public static void ShowWindow()
		{
			var window = GetWindow<HiddenGameObjectTools>();
			window.titleContent = new GUIContent("Hidden GOs");
			window.GatherHiddenObjects();
		}

		#endregion

		#region GUI

		private static readonly GUILayoutOption ButtonWidth = GUILayout.Width(80);
		private static readonly GUILayoutOption BigButtonHeight = GUILayout.Height(35);

		private void OnGUI()
		{
			GUILayout.Space(10f);
			GUILayout.BeginHorizontal();
			{
				if (GUILayout.Button("Refresh", BigButtonHeight))
				{
					GatherHiddenObjects();
				}
				if (GUILayout.Button("Test", BigButtonHeight, ButtonWidth))
				{
					var go = new GameObject("HiddenTestObject");
					go.hideFlags = HideFlags.HideInHierarchy;
					GatherHiddenObjects();
				}
			}
			GUILayout.EndHorizontal();
			GUILayout.Space(10f);

			EditorGUILayout.LabelField("Hidden Objects (" + HiddenObjects.Count + ")", EditorStyles.boldLabel);
			for (int i = 0; i < HiddenObjects.Count; i++)
			{
				var hiddenObject = HiddenObjects[i];
				GUILayout.BeginHorizontal();
				{
					var gone = hiddenObject == null;
					GUILayout.Label(gone ? "null" : hiddenObject.name);
					GUILayout.FlexibleSpace();
					if (gone)
					{
						GUILayout.Box("Select", ButtonWidth);
						GUILayout.Box("Reveal", ButtonWidth);
						GUILayout.Box("Delete", ButtonWidth);
					}
					else
					{
						if (GUILayout.Button("Select", ButtonWidth))
						{
							Selection.activeGameObject = hiddenObject;
						}
						if (GUILayout.Button(IsHidden(hiddenObject) ? "Reveal" : "Hide", ButtonWidth))
						{
							hiddenObject.hideFlags ^= HideFlags.HideInHierarchy;
							EditorSceneManager.MarkSceneDirty(hiddenObject.scene);
						}
						if (GUILayout.Button("Delete", ButtonWidth))
						{
							var scene = hiddenObject.scene;
							DestroyImmediate(hiddenObject);
							EditorSceneManager.MarkSceneDirty(scene);
						}
					}
				}
				GUILayout.EndHorizontal();
			}
		}

		#endregion

		#region Hidden Objects

		private List<GameObject> HiddenObjects = new List<GameObject>();

		// This is really bad code but it's an editor script sooo... ¯\_(ツ)_/¯
		private void GatherHiddenObjects()
		{
			HiddenObjects.Clear();

			var allObjects = FindObjectsOfType<GameObject>();
			foreach (var go in allObjects)
			{
				foreach (var child in go.GetComponentsInChildren<Transform>())
				{
					if (IsHidden(child.gameObject))
					{
						HiddenObjects.Add(child.gameObject);
					}
				}
			}

			HiddenObjects = HiddenObjects.Distinct().ToList();

			Repaint();
		}

		private static bool IsHidden(GameObject go)
		{
			return go.hideFlags != HideFlags.None;
		}

		#endregion
	}
}
