using System;
using System.Collections.Generic;

namespace Fsi.StateMachine
{
    public class Transition
    {
        public IState Source { get; set; }
        
        public IState Target { get; private set; }
        
        private List<Func<bool>> conditions = new();

        private List<Action> onComplete = new();

        public Transition To(IState to)
        {
            Target = to;
            return this;
        }

        public Transition When(Func<bool> condition)
        {
            conditions ??= new List<Func<bool>>();
            conditions.Add(condition);

            return this;
        }

        public Transition OnComplete(Action callback)
        {
            onComplete ??= new List<Action>();
            onComplete.Add(callback);

            return this;
        }
        
        public bool CanTransition()
        {
            if (Source == null || Target == null)
            {
                return false;
            }
            
            if (!Source.CanTransitionOut() || !Target.CanTransitionIn())
            {
                return false;
            }
            
            foreach (Func<bool> condition in conditions)
            {
                if (!condition.Invoke())
                {
                    return false;
                }
            }

            return true;
        }

        public void Complete()
        {
            foreach (Action c in onComplete)
            {
                c?.Invoke();
            }
        }
    }
}