using UnityEngine;

namespace General_Logic.Variables
{
    [CreateAssetMenu(fileName = "NewFloatVariable", menuName = "Data/Variables/FloatVariable")]
    public class FloatVariable : AbstractVariable<float>
    {
        public void Add(float value)
        {
            runtimeValue += value;
            if(onValueChanged != null) onValueChanged.Raise();
        }

        public void Add(FloatVariable value)
        {
            runtimeValue += value.runtimeValue;
            if(onValueChanged != null) onValueChanged.Raise();
        }
    }
}
