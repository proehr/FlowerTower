using UnityEngine;

namespace TowerDefense.Combat.Tower.AggroRange
{
    public class AggroRangeVisualizer : MonoBehaviour
    {
        [SerializeField] private TowerBehaviour tower;
        [SerializeField] private GameObject radiusVisual;

        void Update()
        {
            float towerRadius = tower.CalculateAggroRange();
            radiusVisual.transform.localScale = new Vector3(2f*towerRadius, 0.01f, 2f*towerRadius);
        }
    }
}