using System;

namespace General_Logic.Variables
{
    [Serializable]
    public class FloatReference : AbstractReference<float>
    {
        public FloatReference(float value) : base(value)
        {
        }
    }
}
