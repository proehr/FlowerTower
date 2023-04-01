using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlowerTower
{
    public class AggroRangeVisualizer : MonoBehaviour
    {
        float towerRadius;
        TowerBehaviour tower;
        // Start is called before the first frame update
        void OnEnable()
        {
            tower = GetComponentInParent<TowerBehaviour>();
        }

        // Update is called once per frame
        void Update()
        {
            towerRadius = tower.CalculateAggroRange();
            transform.localScale = new Vector3(2f*towerRadius, 0.01f, 2f*towerRadius);
        }
    }
}