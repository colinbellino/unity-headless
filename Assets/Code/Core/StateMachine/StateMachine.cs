using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Greed.Core
{
	public class StateMachine : ITickable
	{
		private readonly Dictionary<Type, IState> _availableStates;
		private IState _currentState;

		public StateMachine(List<IState> availableStates)
		{
			_availableStates = availableStates.ToList().ToDictionary(item => item.GetType(), item => item);
			ChangeState(availableStates.First());
		}

		public void Tick()
		{
			if (_currentState != null)
			{
				_currentState.Tick();
			}
		}

		private void ChangeState(IState state)
		{
			if (_currentState != null)
			{
				_currentState.OnExit();
				_currentState.OnTransition -= Transition;
			}

			_currentState = state;

			if (_currentState != null)
			{
				_currentState.OnTransition += Transition;
				_currentState.OnEnter();
			}
		}

		private void Transition(string eventName)
		{
			_currentState.Transitions.TryGetValue(eventName, out var newState);
			if (newState == null)
			{
				throw new Exception("Invalid state transition => " + eventName);
			}

			ChangeState(_availableStates[newState]);
		}
	}
}
