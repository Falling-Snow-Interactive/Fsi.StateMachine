using System.Collections.Generic;
using UnityEngine;

namespace Fsi.StateMachine
{
    public class StateMachine
    {
        private readonly Dictionary<IState, List<Transition>> transitions;
        
        private IState CurrentState { get; set; }

        private readonly IState defaultState;
        
        public bool Debugging { get; set; }

        public StateMachine(IState defaultState)
        {
            this.defaultState = defaultState;
            transitions = new Dictionary<IState, List<Transition>>();
        }

        public void SetState(IState state)
        {
            if (Debugging)
            {
                Debug.Log(CurrentState != null
                              ? $"{CurrentState.Name} -> {state.Name}"
                              : $"Starting State: {state.Name}");
            }

            CurrentState?.ExitState();
            CurrentState = state;
            CurrentState?.EnterState();
        }

        public void UpdateState()
        {
            CurrentState?.UpdateState();

            if (CurrentState != null && transitions.ContainsKey(CurrentState))
            {
                foreach (Transition transition in transitions[CurrentState])
                {
                    if (transition.CanTransition())
                    {
                        SetState(transition.Target);
                        transition.Complete();
                    }
                }
            }
        }

        public Transition From(IState from)
        {
            Transition transition = new()
                                       {
                                           Source = from
                                       };

            if (!transitions.TryGetValue(from, out List<Transition> t))
            {
                transitions.Add(from, new List<Transition>());
            }

            transitions[from].Add(transition);
            
            return transition;
        }

        public void Start()
        {
            SetState(defaultState);
        }
    }
}
