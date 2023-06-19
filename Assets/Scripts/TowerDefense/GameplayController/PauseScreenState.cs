using System;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

namespace TowerDefense.GameplayController
{
    public class PauseScreenState : IState
    {
        private readonly TimeManipulation timeManipulation;
        private readonly GameObject pauseScreen;

        public PauseScreenState(TimeManipulation timeManipulation, GameObject pauseScreen)
        {
            this.timeManipulation = timeManipulation;
            this.pauseScreen = pauseScreen;
        }
        
        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            pauseScreen.SetActive(true);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            pauseScreen.SetActive(false);
        }

        private readonly List<Type> nextStates = new() {typeof(TDGameplayState)};


        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}