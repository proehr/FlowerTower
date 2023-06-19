using System;
using System.Collections.Generic;
using GameController;
using StateMachine;
using TowerDefense.LevelSelection;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace TowerDefense.GameplayController
{
    internal class TDGameplayState : IState
    {
        private readonly GameplayData_SO gameplayData;
        private readonly GameObject levelSlot;
        private readonly Transform cardViewParent;

        private LevelSelection.Level activeLevel;

        public TDGameplayState(GameplayData_SO gameplayData, GameObject levelSlot, Transform cardViewParent)
        {
            this.gameplayData = gameplayData;
            this.levelSlot = levelSlot;
            this.cardViewParent = cardViewParent;
        }


        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            gameplayData.KillCount.Set(0);

            // TODO: ew. currently not deleting the "Empty Card Stack" item, so starting at i=1
            for (int i = 1; i < cardViewParent.transform.childCount; i++)
            {
                Object.Destroy(cardViewParent.GetChild(i).gameObject);
            }

            LevelSelection.Level gameplayDataLevelPrefab = gameplayData.LevelPrefabs[gameplayData.CurrentLevelIndex];
            activeLevel = Object.Instantiate(gameplayDataLevelPrefab, levelSlot.transform);

            foreach (GameObject towerCard in activeLevel.availableTowerCards)
            {
                Object.Instantiate(towerCard, cardViewParent);
            }
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            Object.Destroy(activeLevel.gameObject);
        }

        private readonly List<Type> nextStates = new() { typeof(RoundResultScreenState), typeof(PauseMenuState) };

        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}