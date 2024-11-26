using System;

namespace Fsi.StateMachine
{
    public class SubState : IState
    {
        public string Name { get; set; }
        
        public void EnterState()
        {
            Enter?.Invoke();
        }

        public void UpdateState()
        {
            Update?.Invoke();
        }

        public void ExitState()
        {
            Exit?.Invoke();
        }
        
        public bool CanTransitionIn()
        {
            return true;
        }

        public bool CanTransitionOut()
        {
            return true;
        }
        
        public Action Enter { get; set; }
        public Action Exit { get; set; }
        public Action Update { get; set; }
    }
}