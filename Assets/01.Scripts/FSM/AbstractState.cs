namespace _01.Scripts.FSM
{
    public abstract class AbstractState
    {
        protected StateMachine _stateMachine;
        protected IStateController _stateController;
        
        public AbstractState(StateMachine stateMachine, IStateController stateController)
        {
            _stateController = stateController;
            _stateMachine = stateMachine;
        }
        
        
        public virtual void Enter()
        {
            
        }

        public virtual void Exit()
        {
            
        }

        public virtual void StateUpdate()
        {
            
        }

        public virtual void TriggerCalled()
        {
            
        }
    }
}