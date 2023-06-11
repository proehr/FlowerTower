using UnityEngine;
using UnityEngine.Serialization;

namespace TowerDefense.Combat.Enemy.Data
{
    [CreateAssetMenu(fileName = "EnemyConfiguration.asset", menuName = "FlowerTower/TowerDefense/Enemy Configuration",
        order = 1)]
    public class EnemyConfiguration : ScriptableObject
    {
        /// <summary>
        /// The enemy prefab that will be used on instantiation
        /// </summary>
        public Enemy enemyPrefab;
    }
}