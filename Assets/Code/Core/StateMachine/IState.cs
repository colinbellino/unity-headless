using System;
using System.Collections.Generic;

namespace Greed.Core
{
	public interface IState
	{
		Dictionary<string, Type> Transitions { get; }

		void OnExit();
		void OnEnter();
		void Tick();

		Action<string> OnTransition { get; set; }
	}
}
