using Greed.UnityWrapper;

namespace Greed.Core
{
	public class MenuView : IMenuView
	{
		private readonly IGameObject _root;

		public MenuView(IGameObject root)
		{
			_root = root;
		}

		public void Show() => _root.SetActive(true);
		public void Hide() => _root.SetActive(false);
	}
}
