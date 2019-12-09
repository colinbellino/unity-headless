using System;
using Zenject;

namespace Greed.Core
{
	public class PickUpHandler : IInitializable, IDisposable
	{
		private readonly SignalBus _signalBus;
		private readonly IEntity _entity;
		private readonly IEntityView _view;

		public PickUpHandler(SignalBus signalBus, IEntity entity, IEntityView view)
		{
			_signalBus = signalBus;
			_entity = entity;
			_view = view;
		}

		public void Initialize()
		{
			_signalBus.Subscribe<PickUpEndedSignal>(PickUpEnded);
		}

		public void Dispose()
		{
			_signalBus.Unsubscribe<PickUpEndedSignal>(PickUpEnded);
		}

		private void PickUpEnded(PickUpEndedSignal args)
		{
			if (args.Target == _entity)
			{
				_view.AttachTo(args.Picker);
			}
		}
	}
}
