using DataStructures.Events;
using UnityEngine;

namespace TowerDefense.LevelSelection
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