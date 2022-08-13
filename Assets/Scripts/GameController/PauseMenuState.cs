using System;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

namespace GameController
{
    internal class PauseMenuState : IState
    {
        
        private GameObject pauseMenuCanvas;

        public PauseMenuState(GameObject pauseMenuCanvas)
        {
            this.pauseMenuCanvas = pauseMenuCanvas;
        }
        
        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            pauseMenuCanvas.SetActive(true);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            pauseMenuCanvas.SetActive(false);
        }

        private readonly List<Type> nextStates = new() {typeof(MainMenuState), typeof(GameplayState)};
        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}