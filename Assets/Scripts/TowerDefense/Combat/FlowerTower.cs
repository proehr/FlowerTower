using System;
using DataStructures.Events;
using TowerDefense.Combat.AttackEffects;
using TowerDefense.GameplayController;
using UnityEngine;

namespace TowerDefense.Combat
{
    public sealed class FlowerTower : Combatant
    {
        [SerializeField] private GameEvent onFlowerTowerDeath;
        [SerializeField] private int maxHealth;

        private void Awake()
        {
            this.currentHealth = maxHealth;
        }

        public override void Attack(Combatant target)
        {
            target.ReceiveAttack(this, new OneHitAttack());
        }
        
        public void OnTriggerEnter(Collider other)
        {
            Enemy.Enemy enemy = other.GetComponent<Enemy.Enemy>();
            if (enemy)
            {
                enemy.BeginCombat(this);
            }
        }
        
        public override void ReceiveAttack(Combatant source, params AttackEffect[] effects)
        {
            base.ReceiveAttack(source, new DirectDamageEffect(1));
            Attack(source);
        }

        public override void HandleDeath(Combatant killer)
        {
            onFlowerTowerDeath.Raise();
        }
    }
}