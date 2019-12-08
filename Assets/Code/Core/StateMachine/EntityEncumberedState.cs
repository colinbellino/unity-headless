using System;
using System.Collections.Generic;
using System.Linq;
namespace Greed.Core
{
	public class EntityEncumberedState : State
	{
		public EntityEncumberedState(Dictionary<string, Type> transitions) : base(transitions) { }

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
