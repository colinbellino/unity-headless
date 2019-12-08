using System;
using System.Collections.Generic;
using System.Linq;

namespace Greed.Core
{
	public class StateMachine
	{
		private readonly Dictionary<Type, State> _availableStates;
		private State _currentState;

		public Action OnStateChanged = delegate { };

		public StateMachine(Dictionary<Type, State> availableStates)
		{
			_availableStates = availableStates;
			_currentState = _availableStates.Values.First();
		}

		public StateMachine(State[] availableStates)
		{
			_availableStates = availableStates.ToList().ToDictionary(item => item.GetType(), item => item);
			ChangeState(availableStates.First());
		}

		private void ChangeState(State state)
		{
			if (_currentState != null)
			{
				_currentState.OnExit();
			}

			_currentState = state;

			if (_currentState != null)
			{
				_currentState.OnEnter();
			}
		}

		public void Transition(string eventName)
		{
			_currentState.Transitions.TryGetValue(eventName, out var newState);
			if (newState == null)
			{
				throw new Exception("Invalid state transition => " + eventName);
			}

			ChangeState(_availableStates[newState]);
		}
	}

	// TODO: Move this
	public abstract class State
	{
		protected readonly IEntityView _view;
		protected readonly Dictionary<string, Type> _transitions;

		public Dictionary<string, Type> Transitions => _transitions;

		public State(IEntityView view, Dictionary<string, Type> transitions)
		{
			_view = view;
			_transitions = transitions;
		}

		public virtual void OnExit() { }

		public virtual void OnEnter() { }
	}

	public class IdleState : State
	{
		public IdleState(IEntityView view, Dictionary<string, Type> transitions) : base(view, transitions) { }

		public override void OnEnter()
		{
			UnityEngine.Debug.Log("IdleState => OnEnter");
		}

		public override void OnExit()
		{
			UnityEngine.Debug.Log("IdleState => OnExit");
		}
	}

	public class EncumberedState : State
	{
		public EncumberedState(IEntityView view, Dictionary<string, Type> transitions) : base(view, transitions) { }

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
