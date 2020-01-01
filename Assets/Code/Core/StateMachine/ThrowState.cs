using Zenject;

namespace Greed.Core
{
	public class ThrowState : State
	{
		private readonly IEntityView _view;
		private readonly PickerHandler _pickUpHandler;
		private readonly InteractiveObjectFinder _objectFinder;
		private readonly EntityInputState _inputState;
		private readonly LazyInject<StateMachine> _stateMachine;

		private bool _isBusy;

		public ThrowState(
			IEntityView view,
			PickerHandler pickUpHandler,
			InteractiveObjectFinder objectFinder,
			EntityInputState inputState,
			LazyInject<StateMachine> stateMachine
		)
		{
			_view = view;
			_pickUpHandler = pickUpHandler;
			_objectFinder = objectFinder;
			_inputState = inputState;
			_stateMachine = stateMachine;
		}

		public override void Tick()
		{
			UnityEngine.Debug.Log("ThrowState > Tick");
		}
	}
}
