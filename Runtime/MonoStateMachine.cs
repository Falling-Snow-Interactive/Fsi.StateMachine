using UnityEngine;

namespace Fsi.StateMachine
{
    public abstract class MonoStateMachine : MonoBehaviour
    {
        private bool active;
        
        protected StateMachine stateMachine;

        protected abstract void BuildStateMap();

        public void Awake()
        {
            BuildStateMap();
        }

        private void FixedUpdate()
        {
            if (active)
            {
                stateMachine?.UpdateState();
            }
        }

        public void Activate()
        {
            active = true;
        }

        public void Deactivate()
        {
            active = false;
        }
    }
}