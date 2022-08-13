using System;
using UnityEngine;

namespace DataStructures.Variables
{
    [Serializable]
    public class AbstractVariable<T> : ScriptableObject
    {
        public T value;
    }
}