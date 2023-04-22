using UnityEngine;

namespace TowerDefense.LevelSelection
{
    [CreateAssetMenu(fileName = "CurrentLevel", menuName = "Data/FlowerTower/CurrentLevel", order = 0)]
    public class CurrentLevel_SO : ScriptableObject
    {
        [SerializeField] private Level levelPrefab;

        internal Level LevelPrefab
        {
            get => levelPrefab;
            set => levelPrefab = value;
        }
    }
}