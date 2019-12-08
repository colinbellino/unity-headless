namespace Greed.Core
{
	public class State : IState
	{
		public virtual void OnEnter() { }
		public virtual void Tick() { }
		public virtual void OnExit() { }
	}
}
