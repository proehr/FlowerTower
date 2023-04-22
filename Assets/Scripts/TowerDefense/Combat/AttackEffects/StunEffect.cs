namespace TowerDefense.Combat.AttackEffects
{
    public class StunEffect : AttackEffect
    {
        protected float duration;
        public StunEffect(float duration)
        {
            this.duration = duration;
        }
        public override void Apply(Combatant victim, Combatant attacker)
        {
            if(victim.actionCooldown < duration)
            {
                victim.actionCooldown = duration;
            }
            
        }

        public override AttackEffectTypes getType()
        {
            return AttackEffectTypes.STUN;
        }

    }

}
