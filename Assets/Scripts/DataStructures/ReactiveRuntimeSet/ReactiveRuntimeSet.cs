using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[CreateAssetMenu(fileName = "ReactiveRuntimeSet", menuName = "Data/ReactiveRuntimeSets/RuntimeSet", order = 0)]
public class ReactiveRuntimeSet<T> : ScriptableObject
{
    protected ReactiveCollection<T> ReactiveCollection = new ReactiveCollection<T>();

    public ReactiveCollection<T> GetCollection() => ReactiveCollection;
    
    public void Add(T t)
    {
        if (ReactiveCollection.Contains(t)) return;
        
        ReactiveCollection.Add(t);
    }

    public void Remove(T t)
    {
        if (!ReactiveCollection.Contains(t)) return;
            
        ReactiveCollection.Remove(t);
    }
}
