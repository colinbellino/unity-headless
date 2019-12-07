using Greed.UnityWrapper;

namespace Greed.Core
{
	public class PanelView : IPanelView
	{
		private readonly IGameObject _root;

		public PanelView(IGameObject root)
		{
			_root = root;
		}

		public void Show() => _root.SetActive(true);
		public void Hide() => _root.SetActive(false);
	}
}
