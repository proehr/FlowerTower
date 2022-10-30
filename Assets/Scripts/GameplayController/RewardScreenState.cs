using System;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

namespace GameplayController
{
    internal class RewardScreenState : IState
    {
        private readonly GameObject rewardScreen;

        public RewardScreenState(GameObject rewardScreen)
        {
            this.rewardScreen = rewardScreen;
        }
        
        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            rewardScreen.SetActive(true);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            rewardScreen.SetActive(false);
        }

        private readonly List<Type> nextStates = new() {typeof(WorldOverviewState)};

        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}