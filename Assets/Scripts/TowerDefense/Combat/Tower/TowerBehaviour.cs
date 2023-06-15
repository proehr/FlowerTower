using System.Collections.Generic;
using TowerDefense.Combat.AttackEffects;
using UnityEngine;

namespace TowerDefense.Combat.Tower
{
    public class TowerBehaviour : Combatant
    {
        protected TowerCombatData currentCombatData;

        [SerializeField] private CapsuleCollider aggroRange;
        [SerializeField] private TowerTypeData typeData;

        private int currentLevel = 0;
        private int killCount;

        private List<Enemy.Enemy> enemies = new();
        private float currentAggro;
        private float aggroCooldown;


        // Start is called before the first frame update
        public virtual void Awake()
        {
            enemies.Clear();
            currentCombatData = new TowerCombatData(typeData.towerLevels[0]);
            currentHealth = currentCombatData.maxHealth;
            attackCooldown = 1 / currentCombatData.attackSpeed;
            actionCooldown = 0;
            aggroCooldown = 0;
            WorldUIHandler.instance.RegisterTower(this);
        }

        public virtual void OnEnable()
        {
            aggroRange.radius = CalculateAggroRange();
        }

        // Update is called once per frame
        public virtual void Update()
        {
            aggroRange.radius = CalculateAggroRange();
            if (actionCooldown <= 0f)
            {
                HandleCombat();
                HandleAggro();
            }
            else
            {
                actionCooldown -= Time.deltaTime;
            }
        }

        private void HandleCombat()
        {
            if (enemies.Count == 0) return;
            if (attackCooldown <= 0f)
            {
                Attack(enemies[0]);
            }
            else
            {
                attackCooldown -= Time.deltaTime;
            }
        }

        protected virtual void HandleAggro()
        {
            if (aggroCooldown <= 0f)
            {
                currentAggro = Mathf.Min(currentAggro + currentCombatData.aggroGenerationAmount,
                    currentCombatData.maxAggroAmount);
                aggroCooldown = 1f / currentCombatData.aggroGenerationSpeed;
            }
            else
            {
                aggroCooldown -= Time.deltaTime;
            }
        }

        public override void Attack(Combatant target)
        {
            target.ReceiveAttack(this, new DirectDamageEffect(currentCombatData.attackDamage));
            attackCooldown = 1 / currentCombatData.attackSpeed;
        }


        public virtual float CalculateAggroRange()
        {
            return currentCombatData.maxAggroRange *
                   Mathf.Sin((currentAggro / currentCombatData.maxAggroAmount) * Mathf.PI / 2f);
        }

        public virtual void OnTriggerEnter(Collider other)
        {
            Enemy.Enemy enemy = other.GetComponent<Enemy.Enemy>();
            if (enemy && !enemies.Contains(enemy))
            {
                enemy.BeginCombat(this);
                enemies.Add(enemy);
            }
        }

        public override void ReceiveDamage(float amount)
        {
            float excess = amount - currentAggro;
            currentAggro = Mathf.Max(0f, currentAggro - amount);
            if (excess > 0f)
                currentHealth -= excess;
        }

        public virtual void RemoveEnemy(Enemy.Enemy enemy)
        {
            if (enemies.Contains(enemy))
            {
                enemies.Remove(enemy);
            }
        }

        public override void ReceiveKillCredit()
        {
            killCount++;
            if (killCount == currentCombatData.killCountForUpgrade)
            {
                currentLevel++;
                currentCombatData = new TowerCombatData(typeData.towerLevels[currentLevel]);
                // TODO visual update for tower upgrade
                WorldUIHandler.instance.setLevel(this, currentLevel);
            }
        }

        public override void HandleDeath(Combatant killer)
        {
            foreach (Enemy.Enemy enemy in enemies)
            {
                enemy.ResetTarget();
            }

            base.HandleDeath(killer);
        }

        public override float getHealthPercentage()
        {
            return currentHealth / currentCombatData.maxHealth;
        }
        public string getName()
        {
            return typeData.name;
        }
    }
}