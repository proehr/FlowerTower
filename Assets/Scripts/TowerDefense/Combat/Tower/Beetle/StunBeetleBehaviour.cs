using TowerDefense.Combat.AttackEffects;
using UnityEngine;

namespace TowerDefense.Combat.Tower.Beetle
{
    public class StunBeetleBehaviour : TowerBehaviour
    {
        [SerializeField] private StunBeetleData stunData;

        private float nextStunAttack = 0f;

        public override void Attack(Combatant target)
        {
            if (nextStunAttack > 0)
            {
                target.ReceiveAttack(this, new DirectDamageEffect(currentCombatData.attackDamage));
                nextStunAttack -= Time.deltaTime;
            }
            else
            {
                target.ReceiveAttack(this, new StunEffect(stunData.stunDuration));
                nextStunAttack = stunData.stunAttackInterval;
            }
            
            attackCooldown = 1 / currentCombatData.attackSpeed;
        }
    }
}