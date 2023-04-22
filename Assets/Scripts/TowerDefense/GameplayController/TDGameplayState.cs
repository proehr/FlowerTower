using System;
using System.Collections.Generic;
using GameController;
using StateMachine;
using TowerDefense.LevelSelection;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TowerDefense.GameplayController
{
    internal class TDGameplayState : IState
    {
        private readonly GameplayData_SO gameplayData;
        private readonly GameObject levelSlot;

        private Level activeLevel;

        public TDGameplayState(GameplayData_SO gameplayData, GameObject levelSlot)
        {
            this.gameplayData = gameplayData;
            this.levelSlot = levelSlot;
        }
        

        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            Level gameplayDataLevelPrefab = gameplayData.LevelPrefabs[gameplayData.CurrentLevelIndex];
            activeLevel = Object.Instantiate(gameplayDataLevelPrefab, levelSlot.transform);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            Object.Destroy(activeLevel);
        }

        private readonly List<Type> nextStates = new() {typeof(RoundResultScreenState), typeof(PauseMenuState)};

        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}