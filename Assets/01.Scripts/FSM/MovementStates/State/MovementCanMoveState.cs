using _01.Scripts.Modules;

namespace _01.Scripts.FSM.MovementFSM.State
{
    public class MovementCanMoveState : AbstractMovementState
    {
        public MovementCanMoveState(StateMachine stateMachine, IStateController stateController, MovementModule _moveMd) : base(stateMachine, stateController, _moveMd)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _moveMd.SetMovable(true);
        }

        public override void Exit()
        {
            base.Exit();
            _moveMd.SetMovable(false);
        }
    }
}