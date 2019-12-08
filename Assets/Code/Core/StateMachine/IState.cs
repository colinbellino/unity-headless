using System;
using System.Collections.Generic;

namespace Greed.Core
{
	public interface IState
	{
		void OnExit();
		void OnEnter();
		void Tick();
	}
}
