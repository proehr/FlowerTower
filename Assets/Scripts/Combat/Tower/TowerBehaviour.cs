using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FlowerTower
{
    [RequireComponent(typeof(Collider))]
    public class TowerBehaviour : Combatant
    {
        CapsuleCollider aggroRange;
        public TowerData data;
        public Queue<Enemy> enemies;
        [SerializeField]
        private TowerCombatData towerLevelData;
        private TowerTypeData towerTypeData;
        public float currentAggro;
        private float attackCooldown;
        private float aggroCooldown;
        private int killsUntilUpgrade = -1;
        // Start is called before the first frame update
        void Awake()
        {
            enemies = new Queue<Enemy>();
            towerTypeData = data.towerType;
            towerLevelData = towerTypeData.getData(data.killCount);
            currentHealth = towerLevelData.maxHealth;
            attackCooldown = 0;
            aggroCooldown = 0;
            killsUntilUpgrade = towerTypeData.getKillsUntilUpgrade(data.killCount);
            Instantiate(towerLevelData.prefab, transform);
        }
        private void OnEnable()
        {
            aggroRange = GetComponent<CapsuleCollider>();
            aggroRange.radius = CalculateAggroRange();
        }

        // Update is called once per frame
        void Update()
        {
            aggroRange.radius = CalculateAggroRange();
            Enemy currentTarget;
            if (attackCooldown <= 0f)
            {
                if (enemies.TryPeek(out currentTarget))
                {
                    currentTarget.ReceiveAttack(this, new DirectDamageEffect(towerLevelData.attackDamage));
                    attackCooldown = 1 / towerLevelData.attackSpeed;
                }
                
            } else
            {
                attackCooldown -= Time.deltaTime;
            }
            if (aggroCooldown <= 0f)
            {
                currentAggro = Mathf.Min(currentAggro + towerLevelData.aggroGenerationAmount, towerLevelData.maxAggroAmount);
                aggroCooldown = 1f / towerLevelData.aggroGenerationSpeed;
            } else
            {
                aggroCooldown -= Time.deltaTime;
            }


        }
        public float CalculateAggroRange()
        {
            return towerLevelData.maxAggroRange * Mathf.Sin((currentAggro / towerLevelData.maxAggroAmount) * Mathf.PI / 2f);
        }

        private void FixedUpdate()
        {
            gameObject.name = data.name + " (" + currentHealth + "/" + towerLevelData.maxHealth + ") - " + currentAggro;
        }

        private void OnTriggerEnter(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy && enemies.Contains(enemy) == false)
            {
                enemy.BeginCombat(this);
                enemies.Enqueue(enemy);
            }
        }
        public virtual void ApplyAttackEffects (Combatant source, AttackEffect[] effects)
        {
            foreach(AttackEffect effect in effects)
            {
                effect.Apply(this, source);
            }
        }
        public override void ReceiveAttack(Combatant source, params AttackEffect[] effects)
        {
            ApplyAttackEffects(source, effects);
            gameObject.name = data.name + " (" + currentHealth + "/" + towerLevelData.maxHealth + ") - " + currentAggro;
        }
        public override void ReceiveDamage(float amount)
        {
            float excess = amount - currentAggro;
            currentAggro = Mathf.Max(0f, currentAggro - amount);
            if (excess > 0f)
                currentHealth -= excess;
        }
        public void RemoveEnemy (Enemy enemy)
        {
            if (enemies.Contains(enemy))
            {
                Queue <Enemy> newQueue = new Queue<Enemy>();
                foreach (Enemy queueEnemy in enemies)
                {
                    if (queueEnemy == enemy)
                        continue;
                    newQueue.Enqueue(queueEnemy);
                }
                enemies = newQueue;
            }
        }
        
        public override void ReceiveKillCredit()
        {
            data.killCount++;
            killsUntilUpgrade--;
            if(killsUntilUpgrade == 0)
            {
                Debug.Log(data.name + " would like to upgrade!");
            }
        }

    }

}
