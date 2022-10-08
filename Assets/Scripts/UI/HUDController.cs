using DataStructures.Events;
using TowerDefense.Level;
using UnityEngine;

namespace UI
{
    public class HUDController : MonoBehaviour
    {
        public void StartWaveButtonPressed()
        {
            if (LevelManager.instanceExists)
            {
                LevelManager.instance.BuildingCompleted();
            }
        }
    }
}