using System;

namespace DataStructures.Variables
{
    [Serializable]
    public class AbstractReference<T>
    {
        public bool UseConstant = true;
        public T ConstantValue;
        public AbstractVariable<T> Variable;

        public T Value
        {
            get { return UseConstant ? ConstantValue : Variable.value; }
        }
    }
}