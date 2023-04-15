using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlowerTower
{
    [CreateAssetMenu(fileName = "TowerTypeData", menuName = "Towers/TowerTypeData")]
    public class TowerTypeData : ScriptableObject
    {
        public TowerCombatData baseTower;
        public TowerCombatData firstUpgradeTower;
        public TowerCombatData secondUpgradeTower;
        public int killCountForFirstUpgrade;
        public int killCountForSecondUpgrade;
        
        public TowerCombatData getData(int killCount)
        {
            if(killCount >= killCountForSecondUpgrade)
            {
                return secondUpgradeTower;
            }
            else if (killCount >= killCountForFirstUpgrade)
            {
                    return firstUpgradeTower;
            }
            else
            {
                return baseTower;
            }
        }
        public int getKillsUntilUpgrade (int killCount)
        {
            if(killCount >= killCountForSecondUpgrade)
            {
                return -1; //We can't upgrade any further
            }
            else if (killCount < killCountForSecondUpgrade && killCount >= killCountForFirstUpgrade)
            {
                return killCountForSecondUpgrade - killCount;
            } else
            {
                return killCountForFirstUpgrade;
            }
        }
    }
}
