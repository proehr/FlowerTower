using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerPlacement
{
    public interface IDroppable
    {
        void OnDrop(bool isSuccessfulDrop);

        GameObject ProvideInstantiatedPrefab();
    }
}
