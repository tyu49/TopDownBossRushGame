using System.Collections.Generic;
using UnityEngine;

namespace _01.Scripts.FSM
{
    public abstract class AbstractStateMachine
    {
        private AbstractState _currentState;
        private Dictionary<StateEnums, AbstractState> _stateDic = new ();
        protected bool _lockedChange;
    
        public virtual void AddState(StateEnums type, AbstractState abstractState)
        {
            if (!_stateDic.TryAdd(type, abstractState))
                Debug.LogError("중복된 키값을 가진 상태 추가 시도");
        }

        public virtual void ChangeState(StateEnums type)
        {
            if (!_stateDic.ContainsKey(type))
            {
                Debug.LogError("존재하지 않는 키값을 통해 변경 시도");
                return;
            }
            _currentState.Exit();
            _currentState = _stateDic[type];
            _currentState.Enter();
        }

        public virtual void Initialize(StateEnums type)
        {
            if (!_stateDic.TryGetValue(type, out var state))
            {
                Debug.LogError("존재하지 않는 키값을 통해 변경 시도");
                return;
            }
            _currentState = state;
        }

        public virtual void UpdateState()
        {
            _currentState.StateUpdate();
        }

        public virtual void CallTrigger()
        {
            _currentState.TriggerCalled();
        }
        public virtual void SetRuledState()
        {
        }

        public virtual void SetDefaultState()
        {
        }



    }
}
