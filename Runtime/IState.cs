using System;

namespace Fsi.StateMachine
{
    public interface IState
    {
        public string Name { get; }
        
        public void EnterState();
        public void UpdateState();
        public void ExitState();
        
        // Transition
        public bool CanTransitionIn();
        public bool CanTransitionOut();
    }
}