using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FlowerTower
{
    public abstract class Combatant : MonoBehaviour
    {
        public float actionCooldown;
        public float currentHealth;
        public abstract void ReceiveAttack(Combatant source, params AttackEffect[] effects);

        public virtual void ReceiveDamage(float amount)
        {
            currentHealth -= amount;
        }

        public virtual void ReceiveKillCredit()
        {
            return;
        }
    }
}
