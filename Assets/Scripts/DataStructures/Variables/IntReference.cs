using System;

namespace General_Logic.Variables
{
    [Serializable]
    public class IntReference : AbstractReference<int>
    {
        public IntReference(int value) : base(value)
        {
        }
    }
}
