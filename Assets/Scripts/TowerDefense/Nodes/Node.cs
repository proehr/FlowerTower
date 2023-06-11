using TowerDefense.Combat.Enemy;
using UnityEngine;

namespace TowerDefense.Nodes
{
	/// <summary>
	/// A point along the path which agents will navigate towards before receiving the next instruction from the NodeSelector
	/// Requires a collider to be added manually.
	/// </summary>
	[RequireComponent(typeof(Collider))]
	public class Node : MonoBehaviour
	{

		/// <summary>
		/// Selection weight of the node
		/// </summary>
		public int weight = 1;

		/// <summary>
		/// Gets the next node from the selector
		/// </summary>
		/// <returns>Next node, or null if this is the terminating node</returns>
		public Node GetNextNode()
		{
			var selector = GetComponent<NodeSelector>();
			if (selector != null)
			{
				return selector.GetNextNode();
			}
			return null;
		}

		/// <summary>
		/// Gets a random point inside the area defined by a node's meshcreator
		/// </summary>
		/// <returns>A random point within the MeshObject's area</returns>
		public Vector3 GetRandomPointInNodeArea()
		{
			// Fallback to our position if we have no mesh
			return transform.position;
		}

		/// <summary>
		/// When agent enters the node area, get the next node
		/// </summary>
		public virtual void OnTriggerEnter(Collider other)
		{
			var agent = other.gameObject.GetComponent<Enemy>();
			if (agent != null)
			{
				agent.GetNextNode(this);
			}
		}

#if UNITY_EDITOR
		/// <summary>
		/// Ensure the collider is a trigger
		/// </summary>
		protected void OnValidate()
		{
			var trigger = GetComponent<Collider>();
			if (trigger != null)
			{
				trigger.isTrigger = true;
			}
		}

		void OnDrawGizmos()
		{
			Gizmos.DrawIcon(transform.position + Vector3.up, "movement_node.png", true);
		}
#endif
	}
}