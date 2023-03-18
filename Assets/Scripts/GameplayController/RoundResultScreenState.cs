using System;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

namespace GameplayController
{
    internal class RoundResultScreenState : IState
    {
        
        private readonly GameObject resultScreen;

        public RoundResultScreenState(GameObject resultScreen)
        {
            this.resultScreen = resultScreen;
        }
        
        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            resultScreen.SetActive(true);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            resultScreen.SetActive(false);
        }

        private readonly List<Type> nextStates = new() {typeof(TDGameplayState)};


        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}