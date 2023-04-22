using System;

namespace General_Logic.Variables
{
    [Serializable]
    public class DoubleReference : AbstractReference<double>
    {
        public DoubleReference(double value) : base(value)
        {
        }
    }
}
