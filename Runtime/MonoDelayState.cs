using UnityEngine;

namespace Fsi.StateMachines
{
    public class MonoDelayState : MonoState
    {
        [SerializeField]
        private float delay = 1;

        [SerializeField]
        private float timer;
        
        public override void OnEnter()
        {
            timer = delay;
            Active = true;
        }

        public override void OnUpdate()
        {
            if (!Active)
            {
                return;
            }
            
            timer -= Time.deltaTime;
        }

        public override void OnExit()
        {
            timer = 0;
        }

        public override bool CanTransitionIn() => true;

        public override bool CanTransitionOut() => timer <= 0;
    }
}