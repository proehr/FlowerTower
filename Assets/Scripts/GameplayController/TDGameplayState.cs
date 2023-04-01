using System;
using System.Collections.Generic;
using LevelSelection;
using StateMachine;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameplayController
{
    internal class TDGameplayState : IState
    {
        private readonly GameObject levelSlot;
        private readonly CurrentLevel_SO currentLevel;

        private GameObject activeLevel;

        public TDGameplayState(GameObject levelSlot, CurrentLevel_SO currentLevel)
        {
            this.levelSlot = levelSlot;
            this.currentLevel = currentLevel;
        }
        

        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            activeLevel = Object.Instantiate(currentLevel.LevelPrefab.gameObject, levelSlot.transform);
            levelSlot.SetActive(true);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            Object.Destroy(activeLevel);
            levelSlot.SetActive(false);
        }

        private readonly List<Type> nextStates = new() {typeof(RoundResultScreenState)};

        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}