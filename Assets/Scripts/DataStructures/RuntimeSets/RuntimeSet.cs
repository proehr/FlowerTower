using System.Collections.Generic;
using UnityEngine;

namespace DataStructures.RuntimeSets
{
    [CreateAssetMenu(fileName = "RuntimeSet", menuName = "Data/RuntimeSets/RuntimeSet", order = 0)]
    public class RuntimeSet<T> : ScriptableObject
    {
        public List<T> items = new List<T>();

        public void Add(T t)
        {
            if(!items.Contains(t))
            {
                items.Add(t);
            }
        }

        public void Remove(T t)
        {
            if (items.Contains(t))
            {
                items.Remove(t);
            }
        }
    }
}