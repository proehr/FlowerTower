using TowerDefense.Combat.AttackEffects;
using UnityEngine;

namespace TowerDefense.Combat
{
    public abstract class Combatant : MonoBehaviour
    {
        protected internal float actionCooldown;
        protected float attackCooldown;
        protected internal float currentHealth;
        
        public virtual void ReceiveAttack(Combatant source, params AttackEffect[] effects)
        {
            ReceiveAttackEffects(source, effects);
            if (currentHealth <= 0f)
            {
                HandleDeath(source);
            }
        }

        protected void ReceiveAttackEffects(Combatant source, AttackEffect[] effects)
        {
            foreach (AttackEffect effect in effects)
            {
                effect.Apply(this, source);
            }
        }

        public virtual void ReceiveDamage(float amount)
        {
            currentHealth -= amount;
        }

        public virtual void ReceiveKillCredit()
        {
        }
        
        public virtual void HandleDeath(Combatant killer)
        {
            killer?.ReceiveKillCredit();
            Destroy(gameObject);
        }

        public abstract void Attack(Combatant target);
    }
}
