using TowerDefense.Nodes;
using UnityEngine;
using UnityEngine.Serialization;

namespace TowerDefense.Combat.Enemy
{
    public abstract class MovingCombatant : Combatant
    {
        [SerializeField] private protected Animator animator;
        [SerializeField] internal MovementData movementData;
        
        [SerializeField] protected Node currentNode;
        
        private protected readonly int animatorMovementSpeedId = Animator.StringToHash("MovementSpeed");
        private Vector3 target;

        internal void HandleMovement()
        {
            // TODO: extract the distance as variable (or remove this if working with navmesh)
            if (Mathf.Abs((transform.position - target).magnitude) > 0.25f)
            {
                transform.Translate(
                    Time.deltaTime * movementData.movementSpeed * (target - transform.position).normalized);
                animator.SetFloat(animatorMovementSpeedId, movementData.movementSpeed);
            }
            else
            {
                animator.SetFloat(animatorMovementSpeedId, 0);
            }
        }
        
        public void SetTarget(Vector3 newTarget)
        {
            target = newTarget;
        }
        
        /// <summary>
        /// Finds the next node in the path
        /// </summary>
        public virtual void GetNextNode(Node currentlyEnteredNode)
        {
            // Don't do anything if the calling node is different to the m_CurrentNode
            if (currentNode != currentlyEnteredNode)
            {
                return;
            }
            if (currentNode == null)
            {
                Debug.LogError("Cannot find current node");
                return;
            }

            Node nextNode = currentNode.GetNextNode();
            if (nextNode == null)
            {
                HandleDestinationReached();
                return;
            }
			
            Debug.Assert(nextNode != currentNode);
            SetNode(nextNode);
        }
        
        public virtual void SetNode(Node node)
        {
            currentNode = node;
            SetTarget(currentNode.transform.position);
        }
        
        /// <summary>
        /// The logic for what happens when the destination is reached
        /// </summary>
        public virtual void HandleDestinationReached()
        {
            //TODO: consider removing this, the flowerTower handles this by itself
        }
        
        public void ResetTarget()
        {
            SetTarget(currentNode.transform.position);
        }
    }
}