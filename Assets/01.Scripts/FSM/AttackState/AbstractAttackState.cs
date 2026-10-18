using _01.Scripts.Modules;
using UnityEngine;

namespace _01.Scripts.FSM.AttackState
{
    public class AbstractAttackState : AbstractState
    {
        private AttackModule _attackModule;
        private AttackSettingSO _attackData;
        public AbstractAttackState(StateMachine stateMachine, IStateController stateController, AttackModule attackModule, AttackSettingSO attackSetting) : base(stateMachine, stateController)
        {
            _attackData = attackSetting;
            _attackModule = attackModule;
        }

        public override void Enter()
        {
            base.Enter();
            _stateMachine.SetChangeLock(true);
        }

        public override void Exit()
        {
            base.Exit();
            _stateMachine.SetChangeLock(false);
        }
    }
}