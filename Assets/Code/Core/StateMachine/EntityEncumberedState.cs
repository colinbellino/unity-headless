namespace Greed.Core
{
	public class EntityEncumberedState : State
	{
		public override void OnEnter()
		{
			UnityEngine.Debug.Log("EncumberedState => OnEnter");
		}

		public override void OnExit()
		{
			UnityEngine.Debug.Log("EncumberedState => OnExit");
		}
	}
}
