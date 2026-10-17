using _01.Scripts.Modules;
using UnityEngine;

namespace _01.Scripts.FSM.MovementFSM.State
{
    public class MovementDashState: AbstractMovementState
    {
        public MovementDashState(AbstractStateMachine stateMachine, IStateController stateController, MovementModule moveMd) : base(stateMachine, stateController, moveMd)
        {
        }

        private float _dashStTime;
        
        public override void Enter()
        {
            base.Enter();
            _moveMd.SetMovable(false);
            _dashStTime = Time.time;
            _moveMd.TryDash();
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
            if(Time.time > _dashStTime + _moveMd.dashTime)
                _stateMachine.ChangeState(StateEnums.CanMove);
        }

        public override void Exit()
        {
            base.Exit();
            _moveMd.SetMovable(true);
        }
    }
}