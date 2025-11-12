using UnityEngine;

namespace Fsi.StateMachines
{
    public abstract class MonoStateMachine : MonoBehaviour
    {
        public bool Active { get; set; }
        
        private enum StartState
        {
            None = 0,
            Awake = 1,
            Start = 2,
        }

        [SerializeField]
        private StartState startOn;
        
        [SerializeReference]
        protected StateMachines.StateMachine stateMachine;

        protected abstract void BuildStateMap();

        public virtual void Awake()
        {
            BuildStateMap();
            Active = startOn == StartState.Awake;
            if (Active)
            {
                stateMachine.Start();
            }
        }

        protected virtual void Start()
        {
            if (!Active) // if it was started in awake we don't need to do it again
            {
                Active |= startOn == StartState.Start;
                if (Active)
                {
                    stateMachine.Start();
                }
            }
        }

        private void FixedUpdate()
        {
            if (Active)
            {
                stateMachine?.Update();
            }
        }
    }
}