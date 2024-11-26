using UnityEngine;

namespace Fsi.StateMachine
{
    public abstract class MonoState : MonoBehaviour, IState
    {
        [SerializeField]
        private string name = "";

        public string Name => name;
        
        public abstract void EnterState();

        public abstract void UpdateState();

        public abstract void ExitState();

        public abstract bool CanTransitionIn();

        public abstract bool CanTransitionOut();
    }
}