using System;
using _01.Scripts.FSM;
using _01.Scripts.Modules;
using _01.Scripts.UtilClass;
using UnityEngine;

namespace _01.Scripts.Player
{
    public class PlayerController : MonoBehaviour, IHealthHavable, IMovable
    {
        public MovementModule MoveMd { get; private set; }
        public AttackModule AttackMd { get; private set; }
        private InputReader _input;
        private PlayerStateController _stateController;
        private Transform _attackMdTrm;

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

        #region Initialize

        private void GetCompos()
        {
            AttackMd = GetComponentInChildren<AttackModule>();
            _attackMdTrm = AttackMd.transform;
            MoveMd = GetComponentInChildren<MovementModule>();
            _input = GetComponentInChildren<InputReader>();
            _stateController = GetComponentInChildren<PlayerStateController>();
        }
        private void ModulesInit()
        {
            MoveMd.Initialize(GetComponent<Rigidbody2D>());
            AttackMd.Initialize();
            _stateController.Initialize(this);
        }

        #endregion
        #region EventSettting
        #region Event

        private void EventSub()
        {
            _input.OnDir += SetMoveDir;
            _input.OnDashPressed += DashHandler;
            _input.OnAttackPressed += AttackHandler;
        }


        private void EventDisSub()
        {
            _input.OnDir -= SetMoveDir;
            _input.OnDashPressed -= DashHandler;
            _input.OnAttackPressed -= AttackHandler;
        }
        

        #endregion
        #region Handler

        public void SetMoveDir(Vector2 dir) => MoveMd.SetMoveDir(dir);
        private void DashHandler() => _stateController.ChangeState(StateEnums.Dash);
        private void AttackHandler()
        {
            Vector2 dir = GetMousePos.GetPos() - (Vector2)transform.position;
            float rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            float realRotation = Mathf.Round(rotation / 45f) * 45f;
            _attackMdTrm.rotation = Quaternion.Euler(0f,0f,realRotation);
            _stateController.Attack();
        }

        #endregion

        #endregion
    }
}
