using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructures.Events;

namespace FlowerTower {
    public abstract class Enemy : Combatant
    {
        // Used for "Pathfinding"
        public Vector3 startPosition;
        public Vector3 finalGoal;
        public Vector3 target;

        public TowerBehaviour targetTower;
      
        public float minDistanceFromTower;
        public EnemyData data;
        public float attackCooldown;
        // Start is called before the first frame update
        protected virtual void Start()
        {
            Reset();
        }


        // Update is called once per frame
        protected virtual void Update()
        {
            if(actionCooldown > 0f)
            {
                actionCooldown -= Time.deltaTime;
            } else
            {
                HandleCombat();
                HandleMovement();
            }
            
           
        }
        protected virtual void Reset()
        {
            transform.position = startPosition;
            currentHealth = data.maxHealth;
            attackCooldown = 1f / data.attackSpeed;
            SetTarget(finalGoal);
            targetTower = null;
        }
        protected void HandleCombat()
        {
            if (targetTower)
            {
                if (attackCooldown <= 0f)
                {
                    targetTower.ReceiveAttack(this, new DirectDamageEffect(data.attackDamage));
                    attackCooldown += 1 / data.attackSpeed;
                }
                else
                {
                    attackCooldown -= Time.deltaTime;
                }

            }
        }
        protected void HandleMovement()
        {
            //To be overridden be Pathfinding Stuff
            if (Mathf.Abs((transform.position - target).magnitude) > Mathf.Epsilon)
            {
                transform.Translate((target - transform.position).normalized * Time.deltaTime * GetMovementSpeed());
            }
            if (Mathf.Abs((transform.position - finalGoal).magnitude) <= GetMovementSpeed() * Time.deltaTime)
            {
                Reset();
            }
        }
        protected virtual float GetMovementSpeed ()
        {
            return data.movementSpeed;
        }
        protected void SetTarget(Vector3 newTarget)
        {
            //currently just a helper function
            target = newTarget;
        }
        public abstract void BeginCombat(TowerBehaviour tower);

        public override void ReceiveAttack(Combatant source, AttackEffect[] effects)
        {
            ApplyAttackEffects(source, effects);
        }

        protected virtual void ApplyAttackEffects (Combatant source, AttackEffect[] effects)
        {
            foreach(AttackEffect effect in effects)
            {
                effect.Apply(this, source);
                if(currentHealth <= 0f)
                {
                    return;
                }
            }
        }


    }
}