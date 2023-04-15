using UnityEngine;

namespace General_Logic.Variables
{
    [CreateAssetMenu(fileName = "NewDoubleVariable", menuName = "Data/Variables/DoubleVariable")]
    public class DoubleVariable : AbstractVariable<double>
    {
        public void Add(double value)
        {
            runtimeValue += value;
            if(onValueChanged != null) onValueChanged.Raise();
        }

        public void Add(DoubleVariable value)
        {
            runtimeValue += value.runtimeValue;
            if(onValueChanged != null) onValueChanged.Raise();
        }
    }
}
