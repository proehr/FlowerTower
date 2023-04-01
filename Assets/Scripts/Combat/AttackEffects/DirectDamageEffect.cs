using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FlowerTower
{
    public class DirectDamageEffect : AttackEffect
    {
        protected float amount;
        public DirectDamageEffect (float amount)
        {
            this.amount = amount;
        }
        public override void Apply(Combatant victim, Combatant attacker)
        {
            victim.ReceiveDamage(amount);
        }

        public override AttackEffectTypes getType()
        {
            return AttackEffectTypes.DIRECTDAMAGE;
        }
    }

}
