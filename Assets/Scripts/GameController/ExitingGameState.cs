using System;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

namespace GameController
{
    internal class ExitingGameState : IState
    {
        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            Application.Quit();
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
        }

        public bool HasNextState(IState nextState)
        {
            return false;
        }
    }
}