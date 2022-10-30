using System;
using Unity.AI.Navigation;
using UnityEngine;

namespace LevelSelection
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private NavMeshSurface[] surfaces;

        public NavMeshSurface[] Surfaces => surfaces;

        private void Awake()
        {
            foreach (NavMeshSurface navMeshSurface in surfaces)
            {
                navMeshSurface.BuildNavMesh();
            }
        }
    }
}