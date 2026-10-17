using System;
using PrimeTween;
using UnityEngine;

namespace _01.Scripts.Modules
{
    public class MovementModule : MonoBehaviour
    {
        [field:SerializeField] public float DashCool { get; private set; }
        [SerializeField] private float defaultSpeed;
        [SerializeField] private float dashPow;
        [field:SerializeField] public float dashTime { get; private set; }
        private float _speed;
        private Rigidbody2D _rb;
        private Vector2 _curDir;
        private bool _canMove = true;
        
        public void Initialize(Rigidbody2D rb)
        {
            _rb = rb;
            _speed = defaultSpeed;
        }

        public void SetMoveDir(Vector2 dir)
        {
            _curDir = dir;
        }
        
        private void TryMove()
        {
            if (!_canMove) return;
            _rb.linearVelocity = _curDir * _speed;
        }

        public void TryDash()
        {
            _rb.linearVelocity = _curDir * dashPow;
        }

        public void StopMovement()
        {
            _rb.linearVelocity = Vector2.zero;
        }

        private void FixedUpdate()
        {
            TryMove();
        }

        public void SetMovable(bool value)
        {
            _canMove = value;
        }
    }
}