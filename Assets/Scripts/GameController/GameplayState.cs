﻿using System;
using System.Collections.Generic;
using StateMachine;
using TowerDefense.GameplayController;
using UnityEngine;

namespace GameController
{
    internal class GameplayState : IState
    {
        private readonly GameplayController gameplayController;

        public GameplayState(GameplayController gameplayController)
        {
            this.gameplayController = gameplayController;
        }
        
        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            gameplayController.gameObject.SetActive(true);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            gameplayController.gameObject.SetActive(false);
        }

        private readonly List<Type> nextStates = new() {typeof(PauseMenuState)};


        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}