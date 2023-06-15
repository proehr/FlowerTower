using System.Collections.Generic;
using DataStructures.Events;
using UnityEngine;

namespace DataStructures.RuntimeSets
{
    [CreateAssetMenu(fileName = "RuntimeSet", menuName = "Data/RuntimeSets/RuntimeSet", order = 0)]
    public class RuntimeSet<T> : ScriptableObject
    {
        [SerializeField] protected GameEvent onValueChanged;
        public List<T> items = new List<T>();

        public void Add(T t)
        {
            if (items.Contains(t)) return;
            
            items.Add(t);
            if(onValueChanged != null) onValueChanged.Raise();
        }

        public void Remove(T t)
        {
            if (!items.Contains(t)) return;
            
            items.Remove(t);
            if(onValueChanged != null) onValueChanged.Raise();
        }
    }
}