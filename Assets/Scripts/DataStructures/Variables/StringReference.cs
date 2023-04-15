using System;

namespace General_Logic.Variables
{
    [Serializable]
    public class StringReference : AbstractReference<string>
    {
        public StringReference(string value) : base(value)
        {
        }
    }
}
