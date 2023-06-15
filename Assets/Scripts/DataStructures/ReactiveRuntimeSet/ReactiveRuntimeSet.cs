using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[CreateAssetMenu(fileName = "ReactiveRuntimeSet", menuName = "Data/ReactiveRuntimeSets/RuntimeSet", order = 0)]
public class ReactiveRuntimeSet<T> : ScriptableObject
{
    protected ReactiveCollection<T> items = new ReactiveCollection<T>();

    public ReactiveCollection<T> GetCollection() => items;
    
    public void Add(T t)
    {
        if (items.Contains(t)) return;
        
        items.Add(t);
    }

    public void Remove(T t)
    {
        if (!items.Contains(t)) return;
            
        items.Remove(t);
    }
}
