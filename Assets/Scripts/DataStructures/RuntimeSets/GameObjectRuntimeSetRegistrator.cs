using UnityEngine;

namespace DataStructures.RuntimeSets
{
    public class GameObjectRuntimeSetRegistrator : RuntimeSetRegistrator<GameObject>
    {
        protected override GameObject GetComponent()
        {
            return gameObject;
        }
    }
}
