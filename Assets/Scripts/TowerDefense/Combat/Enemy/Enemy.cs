using TowerDefense.Combat.AttackEffects;
using TowerDefense.Combat.Tower;
using UnityEngine;

namespace TowerDefense.Combat.Enemy
{
    public class Enemy : MovingCombatant
    {

        [SerializeField] protected EnemyData enemyData;
        
        [SerializeField] protected Vector3 flowerTower;
        [SerializeField] protected TowerBehaviour targetTower;

        [SerializeField] private float minDistanceFromTower;

        // Start is called before the first frame update
        protected virtual void Start()
        {
            currentHealth = enemyData.maxHealth;
            attackCooldown = 1f / enemyData.attackSpeed;
            targetTower = null;
        }


        // Update is called once per frame
        public override void Update()
        {
            if (actionCooldown > 0f)
            {
                actionCooldown -= Time.deltaTime;
            }
            else
            {
                HandleCombat();
                HandleMovement();
            }
        }

        private void HandleCombat()
        {
            if (targetTower)
            {
                if (attackCooldown <= 0f)
                {
                    Attack(targetTower);
                }
                else
                {
                    attackCooldown -= Time.deltaTime;
                }
            }
            if (Mathf.Abs((transform.position - flowerTower).magnitude) <= movementData.movementSpeed * Time.deltaTime)
            {
                // TODO: attack flower
                HandleDeath(null);
            }
        }

        public override void Attack(Combatant target)
        {
            target.ReceiveAttack(this, new DirectDamageEffect(enemyData.attackDamage));
            attackCooldown += 1 / enemyData.attackSpeed;
        }

        public virtual void BeginCombat(TowerBehaviour tower)
        {
            targetTower = tower;
            float distance = Mathf.Abs((transform.position - tower.transform.position).magnitude);

            SetTarget(Vector3.Lerp(
                transform.position,
                tower.transform.position,
                (distance - minDistanceFromTower) / distance));
        }

        public override void HandleDeath(Combatant killer)
        {
            if (killer as TowerBehaviour)
            {
                ((TowerBehaviour) killer).RemoveEnemy(this);
                base.HandleDeath(killer);
            }
        }
    }
}