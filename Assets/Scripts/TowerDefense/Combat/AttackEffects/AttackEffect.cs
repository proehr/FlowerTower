namespace TowerDefense.Combat.AttackEffects
{
    public enum AttackEffectTypes {DIRECT_DAMAGE, STUN, DOT_POISON, SLOW, ONE_HIT}
    public abstract class AttackEffect
    {
        public abstract void Apply(Combatant victim, Combatant attacker);
        
        // TODO: do we want to remove this?
        public abstract AttackEffectTypes getType();
    }

}
