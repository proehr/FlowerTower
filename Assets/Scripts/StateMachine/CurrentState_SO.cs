using System;
using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "StateMachine/CurrentState", fileName = "CurrentState", order = 0)]
    public class CurrentState_SO : ScriptableObject
    {
        internal IState currentState;
    }
}