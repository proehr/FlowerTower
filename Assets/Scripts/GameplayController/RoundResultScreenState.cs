using System;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

namespace GameController
{
    internal class RoundResultScreenState : IState
    {
        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
        }

        private readonly List<Type> nextStates = new() {typeof(RewardScreenState)};
        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}