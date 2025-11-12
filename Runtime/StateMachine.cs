using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fsi.StateMachines
{
    [Serializable]
    public class StateMachine
    {
        private readonly Dictionary<IState, List<Transition>> transitions;

        private IState state;
        private IState State
        {
            get => state;
            set => state = value;
        }

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
                Debug.Log(State != null
                              ? $"{State.Name} -> {state.Name}"
                              : $"Starting State: {state.Name}");
            }

            State?.OnExit();
            State = state;
            State?.OnEnter();
        }

        public void Update()
        {
            State?.OnUpdate();

            if (State != null && transitions.ContainsKey(State))
            {
                foreach (Transition transition in transitions[State])
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
