using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FlowerTower
{
    [CreateAssetMenu(fileName ="TowerData", menuName = "Towers/TowerData")]
    public class TowerData : ScriptableObject
    {
        public TowerTypeData towerType;
        public int killCount;
    }
}
