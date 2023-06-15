using UnityEngine;

namespace DataStructures.RuntimeSets
{
    public class GameObjectReactiveRuntimeSetRegistrator : ReactiveRuntimeSetRegistrator<GameObject>
    {
        protected override GameObject GetComponent()
        {
            return gameObject;
        }
    }
}
