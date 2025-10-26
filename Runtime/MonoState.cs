using UnityEngine;

namespace Fsi.StateMachine
{
    public abstract class MonoState : MonoBehaviour, IState
    {
        [SerializeField]
        private new string name = "";
        public string Name => name;
        
        // State behaviours 
        public abstract void EnterState();
        public abstract void UpdateState();
        public abstract void ExitState();

        // Transitions
        public abstract bool CanTransitionIn();
        public abstract bool CanTransitionOut();
    }
}