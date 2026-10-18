using System;
using _01.Scripts.FSM;
using _01.Scripts.FSM.MovementFSM;
using _01.Scripts.FSM.MovementFSM.State;
using UnityEngine;

namespace _01.Scripts.Player
{
    public class PlayerStateController : MonoBehaviour, IStateController
    {
        [SerializeField] private float attackDelay;
        
        private PlayerController _player;
        private StateMachine _multiStateMachine;
        private float _lastAttackTime;
        private int _curAttack;
        public void Initialize(PlayerController player)
        {
            _player = player;
            _multiStateMachine = new StateMachine();
            MakeStates();
            _multiStateMachine.Initialize(StateEnums.CanMove);
        }

        private void MakeStates()
        {
            _multiStateMachine.AddState(StateEnums.CanMove, new MovementCanMoveState(_multiStateMachine, this, _player.MoveMd));
            _multiStateMachine.AddState(StateEnums.Dash, new MovementDashState(_multiStateMachine, this, _player.MoveMd));
        }

        private void Update()
        {
            _multiStateMachine.UpdateState();
        }

        public void ChangeState(StateEnums type) => _multiStateMachine.ChangeState(type);

        public void Attack()
        {
            if (_multiStateMachine.LockedChange) return;
            if (_lastAttackTime + attackDelay > Time.time)
                _curAttack = 1;
            switch (_curAttack)
            {
                case 1:
                    _multiStateMachine.ChangeState(StateEnums.FirstAttack);
                    _curAttack = 2;
                    break;
                case 2:
                    _multiStateMachine.ChangeState(StateEnums.SecondAttack);
                    _curAttack = 3;
                    break;
                case 3:
                    _multiStateMachine.ChangeState(StateEnums.ThirdAttack);
                    _curAttack = 1;
                    break;
            }
            _lastAttackTime = Time.time;
        }
    }
}