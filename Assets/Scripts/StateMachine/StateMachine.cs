using System;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    internal abstract class StateMachine : MonoBehaviour
    {
        [SerializeField] internal CurrentState_SO currentStateSO;

        protected void InitializeStateMachine(IState initialState)
        {
            currentStateSO.currentState = initialState;
            currentStateSO.currentState.Enter();
        }

        protected void TransitionTo(IState targetState)
        {
            if (!currentStateSO.currentState.HasNextState(targetState))
            {
                throw new InvalidOperationException("Invalid state transition");
            }

            currentStateSO.currentState.Exit();
            currentStateSO.currentState = targetState;
            currentStateSO.currentState.Enter();
        }
    }
}