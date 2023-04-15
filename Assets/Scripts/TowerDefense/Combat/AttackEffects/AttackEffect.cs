namespace TowerDefense.Combat.AttackEffects
{
    public enum AttackEffectTypes {DIRECT_DAMAGE, STUN, DOT_POISON, SLOW}
    public abstract class AttackEffect
    {
        public abstract void Apply(Combatant victim, Combatant attacker);
        public abstract AttackEffectTypes getType();
    }

}
