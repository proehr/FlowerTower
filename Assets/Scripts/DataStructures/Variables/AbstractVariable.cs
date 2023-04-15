using DataStructures.Events;
using UnityEngine;

namespace General_Logic.Variables
{
    public abstract class AbstractVariable<T> : ScriptableObject
    {
        [SerializeField] protected T runtimeValue;
        [SerializeField] private T storedValue;
        [SerializeField] protected GameEvent onValueChanged;

        private void OnEnable()
        {
            Restore();
        }

        public void Restore()
        {
            if (storedValue.Equals(runtimeValue)) return;
            runtimeValue = storedValue;
            
            if (onValueChanged == null) return;
            onValueChanged.Raise();
        }

        public T Get() => runtimeValue;

        public void Set(T value)
        {
            if (value.Equals(runtimeValue)) return;
            
            runtimeValue = value;
            if(onValueChanged != null) onValueChanged.Raise();
        }

        public GameEvent GetChangedEvent()
        {
            return onValueChanged;
        }

        public void Copy(AbstractVariable<T> other) => runtimeValue = other.runtimeValue;
    }
}
