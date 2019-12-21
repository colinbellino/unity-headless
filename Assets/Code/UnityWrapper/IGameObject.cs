using UnityEngine;

namespace Greed.UnityWrapper
{
	public interface IGameObject
	{
		bool CompareTag(string tag);
		T GetComponent<T>();
		void Destroy();
		void SetActive(bool value);

		GameObject Original { get; }
		string Name { get; set; }
		bool IsStatic { get; }
	}
}
