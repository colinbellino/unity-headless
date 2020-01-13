using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Greed.Core
{
	public class StateMachine : IInitializable, ITickable
	{
		private readonly Dictionary<Type, Transitions> _transitions;
		private readonly Dictionary<Type, IState> _states;
		private readonly string _debugName;

		private Type _currentType;
		private IState CurrentState => _currentType == null ? null : _states[_currentType];

		public StateMachine(Dictionary<Type, Transitions> transitions, List<IState> states, IEntity entity)
		{
			_transitions = transitions;
			if (entity == null)
			{
				throw new Exception("Missing entity from StateMachine.");
			}
			_debugName = entity.Name;
			_states = states.ToList().ToDictionary(item => item.GetType(), item => item);
		}

		public void Initialize()
		{
			var currentType = _transitions.Keys.First();
			ChangeState(_states[currentType]);
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
				throw new Exception($"{_debugName}: Invalid transition ({_currentType?.Name} => {eventName})");
			}

			ChangeState(_states[newState]);
		}

		private void ChangeState(IState state)
		{
			if (CurrentState != null)
			{
				CurrentState.OnExit();
			}

			// UnityEngine.Debug.Log($"{_debugName}: {_currentType?.Name} => {state.GetType().Name}");
			_currentType = state.GetType();

			if (CurrentState != null)
			{
				CurrentState.OnEnter();
			}
		}

		public class Transitions : Dictionary<string, Type> { }
	}
}
