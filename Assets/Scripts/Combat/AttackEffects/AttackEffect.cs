using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlowerTower
{
    public enum AttackEffectTypes {DIRECTDAMAGE, STUN, DOT_POISON, SLOW}
    public abstract class AttackEffect
    {
        public abstract void Apply(Combatant victim, Combatant attacker);
        public abstract AttackEffectTypes getType();
    }

}
