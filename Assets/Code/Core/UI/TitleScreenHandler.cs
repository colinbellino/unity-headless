using System;
using Zenject;

namespace Greed.Core
{
	public class TitleScreenHandler : IInitializable, IDisposable
	{
		private readonly SignalBus _signalBus;
		private readonly IPanelView _view;

		public TitleScreenHandler(SignalBus signalBus, IPanelView view)
		{
			_view = view;
			_signalBus = signalBus;
		}

		public void Initialize()
		{
			_view.Hide();

			_signalBus.Subscribe<TitleScreenLoadedSignal>(OnTitleScreenLoaded);
			_signalBus.Subscribe<GameStartedSignal>(OnGameStartedSignal);
		}

		public void Dispose()
		{
			_signalBus.Unsubscribe<TitleScreenLoadedSignal>(OnTitleScreenLoaded);
			_signalBus.Unsubscribe<GameStartedSignal>(OnGameStartedSignal);
		}

		private void OnTitleScreenLoaded() => _view.Show();

		private void OnGameStartedSignal() => _view.Hide();
	}
}
