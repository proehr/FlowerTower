using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Combat.Tower
{
    [Serializable]
    public class TowerTypeData
    {
        public string name;
        public List<TowerCombatData> towerLevels;
    }
}
