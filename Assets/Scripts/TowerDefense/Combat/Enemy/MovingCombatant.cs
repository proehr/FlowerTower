using UnityEngine;

namespace TowerDefense.Combat.Enemy
{
    public abstract class MovingCombatant : Combatant
    {
        [SerializeField] internal MovementData movementData;
        
        [SerializeField] private Vector3 target;

        public virtual void Update()
        {
            HandleMovement();
        }

        internal void HandleMovement()
        {
            //To be overridden by Pathfinding Stuff
            if (Mathf.Abs((transform.position - target).magnitude) > Mathf.Epsilon)
            {
                transform.Translate(
                    Time.deltaTime * movementData.movementSpeed * (target - transform.position).normalized);
            }
        }
        
        public void SetTarget(Vector3 newTarget)
        {
            target = newTarget;
        }
    }
}