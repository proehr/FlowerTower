using UnityEngine;

namespace General_Logic.Variables
{
    [CreateAssetMenu(fileName = "NewIntVariable", menuName = "Data/Variables/IntVariable")]
    public class IntVariable : AbstractVariable<int>
    {
        public void Add(int value)
        {
            runtimeValue += value;
            if(onValueChanged != null) onValueChanged.Raise();
        }

        public void Add(IntVariable value)
        {
            runtimeValue += value.runtimeValue;
            if(onValueChanged != null) onValueChanged.Raise();
        }
    }
}
