using _01.Scripts.Modules;
using UnityEngine;

namespace _01.Scripts.FSM.MovementFSM
{
    public class MovementStateMachine : AbstractStateMachine
    {
        public MovementModule MdModule { get; private set; }
        private float _lastDashTime = 0;
        
        public MovementStateMachine(MovementModule mdModule)
        {
            MdModule = mdModule;
        }
        
        public override void ChangeState(StateEnums type)
        {
            if (_lockedChange) return;
            if (type == StateEnums.Dash && _lastDashTime + MdModule.DashCool > Time.time) return;
            if (type == StateEnums.Dash) _lastDashTime = Time.time;
            base.ChangeState(type);
        }

        public override void SetRuledState()
        {
            _lockedChange = true;
            base.ChangeState(StateEnums.BeRuled);
        }

        public override void SetDefaultState()
        {
            ChangeState(StateEnums.CanMove);
            _lockedChange = false;
        }
    }
}