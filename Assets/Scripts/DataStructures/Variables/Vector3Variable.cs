using UnityEngine;

namespace General_Logic.Variables
{
    [CreateAssetMenu(fileName = "NewVector3Variable", menuName = "Data/Variables/Vector3Variable")]
    public class Vector3Variable : AbstractVariable<Vector3>
    {
        public void Add(Vector3 value)
        {
            runtimeValue += value;
            if(onValueChanged != null) onValueChanged.Raise();
        }

        public void Add(Vector3Variable value)
        {
            runtimeValue += value.runtimeValue;
            if(onValueChanged != null) onValueChanged.Raise();
        }
    }
}

