
namespace Fsi.StateMachine
{
    public interface IState
    {
        public string Name { get; }
        
        // State Active
        public bool Active { get; set; }
        
        // Stat control
        public void OnEnter();
        public void OnUpdate();
        public void OnExit();
        
        // Transition control
        public bool CanTransitionIn();
        public bool CanTransitionOut();
    }
}