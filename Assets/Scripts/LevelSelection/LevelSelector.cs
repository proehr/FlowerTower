using System;
using DataStructures.Events;
using Unity.VisualScripting;
using UnityEngine;

namespace LevelSelection
{
    public class LevelSelector : MonoBehaviour
    {
        [SerializeField] private Level levelPrefab;
        [SerializeField] private CurrentLevel_SO currentLevel;
        [SerializeField] private GameEvent onLevelSelected;

        public void OnMouseUpAsButton()
        {
            currentLevel.LevelPrefab = levelPrefab;
            onLevelSelected.Raise();
        }
    }
}