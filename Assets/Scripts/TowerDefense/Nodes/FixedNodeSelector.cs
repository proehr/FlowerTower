using Core.Extensions;
#if UNITY_EDITOR
using UnityEngine;
#endif

namespace TowerDefense.Nodes
{
	/// <summary>
	/// Deterministically selects a node in the order it appears on the list
	/// </summary>
	public class FixedNodeSelector : NodeSelector
	{
		/// <summary>
		/// Index to keep track of what node should be selected next
		/// </summary>
		protected int nodeIndex;

		/// <summary>
		/// Selects the next node using <see cref="nodeIndex" />
		/// </summary>
		/// <returns>The next selected node, or null if there are no valid nodes</returns>
		public override Node GetNextNode()
		{
			if (linkedNodes.Next(ref nodeIndex, true))
			{
				return linkedNodes[nodeIndex];
			}
			return null;
		}

#if UNITY_EDITOR
		protected override void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			base.OnDrawGizmos();
		}
#endif
	}
}