using Zenject;

namespace Greed.Core
{
	public class PlayerController : IInitializable
	{
		private readonly IEntityView _view;
		private readonly StateMachine _stateMachine;

		public PlayerController(
			IEntityView view,
			StateMachine stateMachine
		)
		{
			_view = view;
			_stateMachine = stateMachine;
		}

		public void Initialize()
		{

		}
	}
}
