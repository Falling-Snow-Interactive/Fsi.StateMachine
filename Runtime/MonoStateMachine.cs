using UnityEngine;

namespace Fsi.StateMachine
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
        protected StateMachine stateMachine;

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
            Active |= startOn == StartState.Start;
            if (Active)
            {
                stateMachine.Start();
            }
        }

        private void FixedUpdate()
        {
            if (Active)
            {
                stateMachine?.UpdateState();
            }
        }
    }
}