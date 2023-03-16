using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlowerTower
{
    public class BasicEnemyBehaviour : Enemy
    {
        public bool hasBeenInCombat = false;
        public float initialSprintModifier = 1.5f;
        public float explodeOnDeathDamage = 15;

        //Called when an enemy enters the aggro range of a Tower
        public override void BeginCombat(TowerBehaviour tower)
        {
            hasBeenInCombat = true;
            targetTower = tower;
            float distance = Mathf.Abs((transform.position - tower.transform.position).magnitude);
            
            SetTarget(Vector3.Lerp(
                transform.position,
                tower.transform.position,
                (distance-minDistanceFromTower)/distance));

        }
        public override void ReceiveAttack(Combatant source, AttackEffect[] effects)
        {
            base.ReceiveAttack(source, effects);
            gameObject.name = data.name + " (" + currentHealth + "/" + data.maxHealth + ")";
            if(currentHealth <= 0f)
            {
                HandleDeath(source);
            }
        }
        public void HandleDeath(Combatant killer)
        {
            ExplodeOnDeath();
            targetTower.RemoveEnemy(this);
            killer.ReceiveKillCredit();
            Reset();
        }

        protected void ExplodeOnDeath()
        {
                targetTower?.ReceiveAttack(this, new DirectDamageEffect(explodeOnDeathDamage));
        }

        protected override void Reset()
        {
            base.Reset();
            hasBeenInCombat = false;
        }

        protected override float GetMovementSpeed()
        {
            if (hasBeenInCombat == false)
            {
                return data.movementSpeed * initialSprintModifier;
            }
            else
            {
                return data.movementSpeed;
            }
            
        }
    }

}