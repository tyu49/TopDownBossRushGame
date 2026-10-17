using System;
using _01.Scripts.FSM;
using _01.Scripts.FSM.MovementFSM;
using _01.Scripts.FSM.MovementFSM.State;
using UnityEngine;

namespace _01.Scripts.Player
{
    public class PlayerStateController : MonoBehaviour, IStateController
    {
        private PlayerController _player;
        private MovementStateMachine _moveSM;
        
        public void Initialize(PlayerController player)
        {
            _player = player;
            _moveSM = new MovementStateMachine(_player.moveMd);
            MakeStates();
            SMInitialize();
        }

        private void SMInitialize()
        {
            _moveSM.Initialize(StateEnums.CanMove);
        }

        private void MakeStates()
        {
            _moveSM.AddState(StateEnums.BeRuled, new MovementRuledState(_moveSM, this, _player.moveMd));
            _moveSM.AddState(StateEnums.CanMove, new MovementCanMoveState(_moveSM, this, _player.moveMd));
            _moveSM.AddState(StateEnums.Dash, new MovementDashState(_moveSM, this, _player.moveMd));
        }

        private void Update()
        {
            _moveSM.UpdateState();
        }

        public void ChangeMoveState(StateEnums type) => _moveSM.ChangeState(type);

        public void SetAllDefault(StateEnums ignore)
        {
        }

        public void SetAllRuled(StateEnums ignore)
        {
        }
        
    }

    public enum StateMachineType
    {
        Movement,
        Attack,
        
    }
}