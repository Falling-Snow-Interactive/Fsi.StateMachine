using System;

namespace Fsi.StateMachines
{
    public class SubState : IState
    {
        public string Name { get; set; }
        public bool Active { get; set; }

        public void OnEnter()
        {
            Active = true;
            Enter?.Invoke();
        }

        public void OnUpdate()
        {
            if (!Active)
            {
                return;
            }
            Update?.Invoke();
        }

        public void OnExit()
        {
            Active = false;
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