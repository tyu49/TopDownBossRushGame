using _01.Scripts.Modules;

namespace _01.Scripts.FSM.MovementFSM.State
{
    public class MovementCanMoveState : AbstractMovementState
    {
        public MovementCanMoveState(AbstractStateMachine stateMachine, IStateController stateController, MovementModule _moveMd) : base(stateMachine, stateController, _moveMd)
        {
        }
    }
}