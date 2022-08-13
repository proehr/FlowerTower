using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using IState = StateMachine.IState;

namespace GameController
{
    internal class MainMenuState : IState
    {
        
        private GameObject mainMenuCanvas;

        public MainMenuState(GameObject mainMenuCanvas)
        {
            this.mainMenuCanvas = mainMenuCanvas;
        }
        
        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            mainMenuCanvas.SetActive(true);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            mainMenuCanvas.SetActive(false);
        }

        private readonly List<Type> nextStates = new() {typeof(ExitingGameState), typeof(GameplayState)};
        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}