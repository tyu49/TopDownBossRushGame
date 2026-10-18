using System.Collections.Generic;
using UnityEngine;

namespace _01.Scripts.FSM
{
    public class StateMachine
    {
        private AbstractState _currentState;
        private Dictionary<StateEnums, AbstractState> _stateDic = new ();
        public bool LockedChange { get; private set; }

        public void AddState(StateEnums type, AbstractState abstractState)
        {
            if (!_stateDic.TryAdd(type, abstractState))
                Debug.LogError("중복된 키값을 가진 상태 추가 시도");
        }

        public void ChangeState(StateEnums type)
        {
            if (LockedChange) return;
            if (!_stateDic.ContainsKey(type))
            {
                Debug.LogError("존재하지 않는 키값을 통해 변경 시도");
                return;
            }
            _currentState.Exit();
            _currentState = _stateDic[type];
            _currentState.Enter();
        }

        public void Initialize(StateEnums type)
        {
            if (!_stateDic.TryGetValue(type, out var state))
            {
                Debug.LogError("존재하지 않는 키값을 통해 변경 시도");
                return;
            }
            _currentState = state;
        }

        public void UpdateState()
        {
            _currentState.StateUpdate();
        }

        public void CallTrigger()
        {
            _currentState.TriggerCalled();
        }

        public void SetChangeLock(bool value) => LockedChange = value;




    }
}
