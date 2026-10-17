using _01.Scripts.Modules;
using UnityEngine;

namespace _01.Scripts.FSM.MovementFSM.State
{
    public class MovementDashState: AbstractMovementState
    {
        public MovementDashState(StateMachine stateMachine, IStateController stateController, MovementModule moveMd) : base(stateMachine, stateController, moveMd)
        {
        }

        private float _lastDashTime = 0;
        private bool _didDash;
        public override void Enter()
        {
            base.Enter();
            _didDash = false;
            if(_lastDashTime + _moveMd.DashCool < Time.time)
                _stateMachine.ChangeState(StateEnums.CanMove);
            _didDash = true;
            _moveMd.StopMovement();
            _moveMd.TryDash();
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
        }

        public override void Exit()
        {
            base.Exit();
            if(_didDash)
                _lastDashTime = Time.time;
        }
    }
}