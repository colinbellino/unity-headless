using UnityEngine;

namespace Greed.UnityWrapper
{
	public class UnityGameObject : IGameObject
	{
		private readonly GameObject _gameObject;

		public UnityGameObject(GameObject gameObject)
		{
			_gameObject = gameObject;
		}

		public bool CompareTag(string tag) => _gameObject.CompareTag(tag);

		public void Destroy() => Object.Destroy(_gameObject);

		public T GetComponent<T>() => _gameObject.GetComponent<T>();
	}
}
