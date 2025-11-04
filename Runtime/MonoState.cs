using UnityEngine;

namespace Fsi.StateMachine
{
    public abstract class MonoState : MonoBehaviour, IState
    {
        [SerializeField]
        private new string name = "";
        public string Name => name;
        
        // State Active
        public bool Active { get; set; }

        // State behaviours 
        public virtual void OnEnter()
        {
            Active = true;
        }

        public virtual void OnUpdate()
        {
            if (Active)
            {
                return;
            }
        }

        public virtual void OnExit()
        {
            Active = false;
        }

        // State transitions
        public abstract bool CanTransitionIn();
        public abstract bool CanTransitionOut();
    }
}