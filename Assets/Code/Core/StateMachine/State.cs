using System;
using System.Collections.Generic;

namespace Greed.Core
{
	public class State : IState
	{
		protected readonly Dictionary<string, Type> _transitions;

		public Dictionary<string, Type> Transitions => _transitions;

		public State(Dictionary<string, Type> transitions)
		{
			_transitions = transitions;
		}

		public virtual void OnEnter() { }

		public virtual void Tick() { }

		public virtual void OnExit() { }
	}
}
