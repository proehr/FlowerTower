using System;
using UnityEngine;

namespace General_Logic.Variables
{
    [CreateAssetMenu(fileName = "NewBoolVariable", menuName = "Data/Variables/BoolVariable")]
    public class BoolVariable : AbstractVariable<bool>
    {
        public void Toggle()
        {
            Set(!runtimeValue);
        }
        
        public void SetTrue(Action action)
        {
            Set(true);
        }

        public void SetFalse()
        {
            Set(false);
        }

        public bool Not()
        {
            return !Get();
        }
    }
}
