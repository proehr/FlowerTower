using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FlowerTower
{
    [CreateAssetMenu(fileName = "TowerCombatData", menuName = "Towers/TowerCombatData")]
    public class TowerCombatData : ScriptableObject
    {
        public Object prefab;
        public float attackDamage;
        public float attackSpeed; //float in Attacks per Second
        public float maxHealth;

        public float maxAggroAmount;
        public float maxAggroRange;
        public float aggroGenerationSpeed;
        public float aggroGenerationAmount;

        //public TowerBehaviour CombatBehaviour;

    }

}

