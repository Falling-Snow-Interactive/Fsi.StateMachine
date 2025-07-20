using UnityEngine;

namespace Fsi.StateMachine
{
    public class MonoDelayState : MonoState
    {
        [SerializeField]
        private float delay = 1;

        [SerializeField]
        private float timer;
        
        public override void EnterState()
        {
            timer = delay;
        }

        public override void UpdateState()
        {
            timer -= Time.deltaTime;
        }

        public override void ExitState()
        {
            timer = 0;
        }

        public override bool CanTransitionIn() => true;

        public override bool CanTransitionOut() => timer <= 0;
    }
}