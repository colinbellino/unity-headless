using UniRx.Async;
using Zenject;

namespace Greed.Core
{
	public class EntityPickUpHandler
	{
		private readonly IEntityView _view;
		private readonly IEntity _entity;
		private readonly SignalBus _signalBus;

		private IEntity _cargo;

		public EntityPickUpHandler(SignalBus signalBus, IEntity entity, IEntityView view)
		{
			_signalBus = signalBus;
			_entity = entity;
			_view = view;
		}

		public async UniTask<bool> TryPickUp(IEntity objectToPickUp)
		{
			var canPickUp = CanPickUpObject(objectToPickUp);
			var animationName = canPickUp ? "PickUp" : "PickUpFail";

			_signalBus.Fire(new PickUpStartedSignal { Actor = _entity, Target = objectToPickUp });

			await _view.PlayAnimation(animationName);

			_cargo = objectToPickUp;
			_signalBus.Fire(new PickUpEndedSignal { Actor = _entity, Target = objectToPickUp });

			return canPickUp;
		}

		private bool CanPickUpObject(IEntity objectToPickUp)
		{
			return true;
		}
	}

	public class PickUpStartedSignal
	{
		public IEntity Actor;
		public IEntity Target;
	}

	public class PickUpEndedSignal
	{
		public IEntity Actor;
		public IEntity Target;
	}
}
