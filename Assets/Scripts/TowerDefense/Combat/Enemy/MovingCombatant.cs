using TowerDefense.Nodes;
using UnityEngine;
using UnityEngine.Serialization;

namespace TowerDefense.Combat.Enemy
{
    public abstract class MovingCombatant : Combatant
    {
        [SerializeField] internal MovementData movementData;
        
        [SerializeField] protected Node currentNode;
        private Vector3 target;

        public virtual void Update()
        {
            HandleMovement();
        }

        internal void HandleMovement()
        {
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
            //TODO: whatever happens when enemy has reached flower tower
            HandleDeath(null);
        }
        
        public void ResetTarget()
        {
            SetTarget(currentNode.transform.position);
        }
    }
}