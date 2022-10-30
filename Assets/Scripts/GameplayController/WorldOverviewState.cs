using System;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

namespace GameplayController
{
    internal class WorldOverviewState : IState
    {
        
        private readonly GameObject worldOverviewSlot;

        public WorldOverviewState(GameObject worldOverviewSlot)
        {
            this.worldOverviewSlot = worldOverviewSlot;
        }
        
        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            worldOverviewSlot.SetActive(true);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            worldOverviewSlot.SetActive(false);
        }

        private readonly List<Type> nextStates = new() {typeof(TDGameplayState)};

        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}