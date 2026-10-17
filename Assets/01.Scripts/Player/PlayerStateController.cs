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
        private StateMachine _statMachine;
        
        public void Initialize(PlayerController player)
        {
            _player = player;
            _statMachine = new StateMachine();
            MakeStates();
            _statMachine.Initialize(StateEnums.CanMove);
        }

        private void MakeStates()
        {
            _statMachine.AddState(StateEnums.CanMove, new MovementCanMoveState(_statMachine, this, _player.moveMd));
            _statMachine.AddState(StateEnums.Dash, new MovementDashState(_statMachine, this, _player.moveMd));
        }

        private void Update()
        {
            _statMachine.UpdateState();
        }

        public void ChangeState(StateEnums type) => _statMachine.ChangeState(type);

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