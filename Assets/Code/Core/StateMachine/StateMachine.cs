using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Greed.Core
{
	public class StateMachine : ITickable
	{
		private readonly Dictionary<Type, Transitions> _transitions;
		private readonly Dictionary<Type, IState> _states;

		private Type _currentType;
		private IState CurrentState => _states[_currentType];

		public StateMachine(Dictionary<Type, Transitions> transitions, List<IState> states)
		{
			_transitions = transitions;
			_states = states.ToList().ToDictionary(item => item.GetType(), item => item);
			_currentType = _transitions.Keys.First();

			ChangeState(_states[_currentType]);
		}

		public void Tick()
		{
			if (CurrentState != null)
			{
				CurrentState.Tick();
			}
		}

		public void Transition(string eventName)
		{
			_transitions[_currentType].TryGetValue(eventName, out var newState);
			if (newState == null)
			{
				throw new Exception($"Invalid state transition: {_currentType} => {eventName}");
			}

			ChangeState(_states[newState]);
		}

		private void ChangeState(IState state)
		{
			if (CurrentState != null)
			{
				CurrentState.OnExit();
			}

			UnityEngine.Debug.Log($"{_currentType} => {state.GetType()}");
			_currentType = state.GetType();

			if (CurrentState != null)
			{
				CurrentState.OnEnter();
			}
		}

		public class Transitions : Dictionary<string, Type> { }
	}
}
