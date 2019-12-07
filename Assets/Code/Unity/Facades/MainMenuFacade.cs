using Greed.Core;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class MainMenuFacade : MonoBehaviour, IMainMenu
	{
		private IMenuView _view;

		[Inject]
		public void Construct(IMenuView view)
		{
			_view = view;
		}

		public void Show() => _view.Show();
		public void Hide() => _view.Hide();
	}
}
