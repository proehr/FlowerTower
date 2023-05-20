using System.Collections.Generic;
using DataStructures.Events;
using TowerDefense.GameplayController;
using TowerDefense.LevelSelection;
using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(fileName = "gameplayData", menuName = "Data/FlowerTower/GameplayData", order = 0)]
    public class GameplayData_SO : ScriptableObject
    {
        [SerializeField] private int currentLevelIndex = 0;
        [SerializeField] private List<LevelSelection.Level> levelPrefabs;
        [SerializeField] private ResultType resultType;
        
        
        [SerializeField] private GameEvent onNextRound;
        [SerializeField] private GameEvent onFlowerTowerDeath;
        [SerializeField] private GameEvent onFinalEnemyKilled;

        public int CurrentLevelIndex
        {
            get => currentLevelIndex;
            set => currentLevelIndex = value;
        }

        public List<LevelSelection.Level> LevelPrefabs => levelPrefabs;

        public ResultType ResultType
        {
            get => resultType;
            set => resultType = value;
        }

        public GameEvent OnNextRound => onNextRound;

        public GameEvent OnFlowerTowerDeath => onFlowerTowerDeath;

        public GameEvent OnFinalEnemyKilled => onFinalEnemyKilled;
    }
}