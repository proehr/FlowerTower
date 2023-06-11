using System;
using TowerDefense.Combat.Enemy.Data;
using TowerDefense.Nodes;
using UnityEngine;

namespace TowerDefense.Level
{
	/// <summary>
	/// Serializable class for specifying properties of spawning an enemy
	/// </summary>
	[Serializable]
	public class SpawnInstruction
	{
		/// <summary>
		/// The enemy to spawn - i.e. the monster for the wave
		/// </summary>
		public EnemyConfiguration enemyConfiguration;

		/// <summary>
		/// The delay from the previous spawn until when this enemy is spawned
		/// </summary>
		[Tooltip("The delay from the previous spawn until when this enemy is spawned")]
		public float delayToSpawn;

		/// <summary>
		/// The starting node, where the enemy is spawned
		/// </summary>
		public Node startingNode;
	}
}