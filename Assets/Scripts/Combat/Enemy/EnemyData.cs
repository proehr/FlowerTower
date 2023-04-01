using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FlowerTower
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Towers/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public float maxHealth;
        public float attackDamage;
        public float attackSpeed;

        public float movementSpeed;
    }
}
