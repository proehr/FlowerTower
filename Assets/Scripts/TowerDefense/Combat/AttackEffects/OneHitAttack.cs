namespace TowerDefense.Combat.AttackEffects
{
    public class OneHitAttack : AttackEffect
    {
        public override void Apply(Combatant victim, Combatant attacker)
        {
            victim.ReceiveDamage(victim.currentHealth);
        }

        public override AttackEffectTypes getType()
        {
            return AttackEffectTypes.ONE_HIT;
        }
    }
}