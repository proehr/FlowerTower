using DataStructures.Events;
using UnityEngine;

namespace StateMachine
{
    public interface IState
    {
        void Enter();
        void Exit();

        bool HasNextState(IState nextState);
    }
}