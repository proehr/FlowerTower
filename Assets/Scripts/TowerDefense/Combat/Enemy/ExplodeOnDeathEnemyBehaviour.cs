using TowerDefense.Combat.AttackEffects;
using TowerDefense.Combat.Tower;
using UnityEngine;

namespace TowerDefense.Combat.Enemy
{
    public class ExplodeOnDeathEnemyBehaviour : Enemy
    {
        [SerializeField] private bool hasBeenInCombat = false;
        [SerializeField] private float initialSprintModifier = 1.5f;
        [SerializeField] private float explodeOnDeathDamage = 15;

        private void OnEnable()
        {
            movementData.movementSpeed *= initialSprintModifier;
        }

        //Called when an enemy enters the aggro range of a Tower
        public override void BeginCombat(Combatant tower)
        {
            if (!hasBeenInCombat)
            {
                hasBeenInCombat = true;
                movementData.movementSpeed /= initialSprintModifier;
            }

            base.BeginCombat(tower);
        }

        public override void HandleDeath(Combatant killer)
        {
            ExplodeOnDeath(killer);
            base.HandleDeath(killer);
        }

        private void ExplodeOnDeath(Combatant killer)
        {
            if (killer as TowerBehaviour)
            {
                killer.ReceiveAttack(this, new DirectDamageEffect(explodeOnDeathDamage));
            }
        }
    }
}