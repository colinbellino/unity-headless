namespace Greed.UnityWrapper
{
	public interface IGameObject
	{
		bool CompareTag(string tag);
		T GetComponent<T>();
		void Destroy();
		void SetActive(bool value);
	}
}
