using System;
using _01.Scripts.FSM;
using _01.Scripts.Modules;
using UnityEngine;

namespace _01.Scripts.Player
{
    public class PlayerController : MonoBehaviour, IHealthHavable, IMovable
    {
        public MovementModule moveMd { get; private set; }
        private InputReader _input;
        private PlayerStateController _stateController;

        private void Awake()
        {
            GetCompos();
            EventSub();
            ModulesInit();
        }


        private void OnDestroy()
        {
            EventDisSub();
        }

        public void GetDamage(float damage)
        {
        }

        public  void GetHeal(float heal)
        {
        }

        public  void Push(Vector2 dir, float pow, ForceMode2D forceMode)
        {
        }

        #region Initialize

        private void GetCompos()
        {
            moveMd = GetComponentInChildren<MovementModule>();
            _input = GetComponentInChildren<InputReader>();
            _stateController = GetComponentInChildren<PlayerStateController>();
        }
        private void ModulesInit()
        {
            moveMd.Initialize(GetComponent<Rigidbody2D>());
            _stateController.Initialize(this);
        }

        #endregion
        #region EventSettting
        #region Event

        private void EventSub()
        {
            _input.OnDir += SetMoveDir;
            _input.OnDashPressed += DashHandler;
        }

        private void EventDisSub()
        {
            _input.OnDir -= SetMoveDir;
            _input.OnDashPressed -= DashHandler;
        }
        

        #endregion
        #region Handler

        public void SetMoveDir(Vector2 dir) => moveMd.SetMoveDir(dir);
        private void DashHandler() => _stateController.ChangeState(StateEnums.Dash);

        #endregion

        #endregion
    }
}
