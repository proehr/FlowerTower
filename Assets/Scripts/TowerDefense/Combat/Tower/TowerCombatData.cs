using System;
using Object = UnityEngine.Object;

namespace TowerDefense.Combat.Tower
{
    [Serializable]
    public class TowerCombatData
    {
        public float attackDamage;
        public float attackSpeed; //float in Attacks per Second
        public float maxHealth;

        public float maxAggroAmount;
        public float maxAggroRange;
        public float aggroGenerationSpeed;
        public float aggroGenerationAmount;

        public int killCountForUpgrade;

        public TowerCombatData(TowerCombatData towerCombatData)
        {
            this.attackDamage = towerCombatData.attackDamage;
            this.attackSpeed = towerCombatData.attackSpeed;
            this.maxHealth = towerCombatData.maxHealth;
            this.maxAggroAmount = towerCombatData.maxAggroAmount;
            this.maxAggroRange = towerCombatData.maxAggroRange;
            this.aggroGenerationSpeed = towerCombatData.aggroGenerationSpeed;
            this.aggroGenerationAmount = towerCombatData.aggroGenerationAmount;
            this.killCountForUpgrade = towerCombatData.killCountForUpgrade;
        }
    }
}