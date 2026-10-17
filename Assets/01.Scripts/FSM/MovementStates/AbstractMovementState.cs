using _01.Scripts.Modules;

namespace _01.Scripts.FSM.MovementFSM
{
    public class AbstractMovementState : AbstractState
    {
        protected MovementModule _moveMd;
        
        public AbstractMovementState(StateMachine stateMachine, IStateController stateController, MovementModule _moveMd) : base(stateMachine, stateController)
        {
            this._moveMd = _moveMd;
        }
    }
}