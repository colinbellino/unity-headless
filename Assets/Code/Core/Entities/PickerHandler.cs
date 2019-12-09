using UniRx.Async;
using Zenject;

namespace Greed.Core
{
	public class PickerHandler
	{
		private readonly IEntity _entity;
		private readonly IEntityView _view;
		private readonly SignalBus _signalBus;

		public PickerHandler(SignalBus signalBus, IEntity entity, IEntityView view)
		{
			_signalBus = signalBus;
			_entity = entity;
			_view = view;
		}

		public async UniTask<bool> TryPickUp(IEntity entityToPickUp)
		{
			var canPickUp = CanPickUpObject(entityToPickUp);
			var animationName = canPickUp ? "PickUp" : "PickUpFail";

			_signalBus.Fire(new PickUpStartedSignal { Picker = _entity, Target = entityToPickUp });

			await _view.PlayAnimation(animationName);

			_signalBus.Fire(new PickUpEndedSignal { Picker = _entity, Target = entityToPickUp });

			return canPickUp;
		}

		private bool CanPickUpObject(IEntity entityToPickUp)
		{
			return true;
		}
	}

	public class PickUpStartedSignal
	{
		public IEntity Picker;
		public IEntity Target;
	}

	public class PickUpEndedSignal
	{
		public IEntity Picker;
		public IEntity Target;
	}
}
