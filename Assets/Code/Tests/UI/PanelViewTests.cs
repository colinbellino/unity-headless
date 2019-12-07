using Greed.Core;
using Greed.UnityWrapper;
using NSubstitute;
using NUnit.Framework;

namespace Greed.Tests
{
	public class PanelViewTests
	{
		private PanelView _view;

		private IGameObject _gameObject;

		[SetUp]
		public void SetUp()
		{
			_gameObject = Substitute.For<IGameObject>();

			_view = new PanelView(_gameObject);
		}

		[Test]
		public void Show_ActivateTheGameObject()
		{
			_view.Show();
			ThenSetGameObjectActive(true);
		}

		[Test]
		public void Hide_DeactivateTheGameObject()
		{
			_view.Hide();
			ThenSetGameObjectActive(false);
		}

		private void ThenSetGameObjectActive(bool active)
		{
			_gameObject.Received().SetActive(active);
		}
	}
}
