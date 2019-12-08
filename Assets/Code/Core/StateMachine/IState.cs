using System;
using System.Collections.Generic;

namespace Greed.Core
{
	public interface IState
	{
		// TODO: Move this to StateMachine.cs
		Dictionary<string, Type> Transitions { get; }

		void OnExit();
		void OnEnter();
		void Tick();
	}
}
