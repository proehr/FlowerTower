using UniRx;
using UnityEngine;

namespace DataStructures.ReactiveVariable
{
    public class AbstractReactiveVariable<T> : ScriptableObject
    {
        [SerializeField] protected ReactiveProperty<T> runtimeProperty;
        [SerializeField] protected T storedValue;

        protected ReactiveProperty<T> RuntimeProperty => runtimeProperty;
    
        private void OnEnable()
        {
            Restore(false);
        }

        public void Restore(bool keepSubscriptions)
        {
            if (keepSubscriptions && runtimeProperty != null)
            {
                runtimeProperty.Value = storedValue;
            }
            else
            {
                runtimeProperty = new ReactiveProperty<T>(storedValue);
            }
        }

        public ReactiveProperty<T> GetProperty => runtimeProperty;

        public T GetValue() => runtimeProperty.Value;

        public void Set(T value)
        {
            if (value.Equals(runtimeProperty.Value)) return;
            
            runtimeProperty.Value = value;
        }

        public void SetProperty(ReactiveProperty<T> property)
        {
            runtimeProperty = property;
        }
    }
}
