using System;
using DataStructures.ReactiveVariable;
using DataStructures.RuntimeSets;
using TMPro;
using UniRx;
using UnityEngine;

namespace TowerPlacement
{
    public class KillRequirementVisualization : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
    
        [Header("Kill Requirement")]
        [SerializeField] private GameObjectReactiveRuntimeSet placedTowerReactiveRuntimeSet;
        [SerializeField] private IntReactiveVariable killCount;

        private IDisposable _killDisposable;
        private IDisposable _runtimeSetDisposable;

        private void Start()
        {
            _killDisposable = killCount.GetProperty.Subscribe(_ => UpdateKillRequirementText());
            _runtimeSetDisposable = placedTowerReactiveRuntimeSet.GetCollection().ObserveCountChanged().Subscribe(_ => UpdateKillRequirementText());
        }

        private void OnDestroy()
        {
            _killDisposable.Dispose();
            _runtimeSetDisposable.Dispose();
        }

        private void UpdateKillRequirementText()
        {
            int bufferKillCount = killCount.GetValue();
            int placedTowerCount = placedTowerReactiveRuntimeSet.GetCollection().Count;
        
            for (int i = 1; i < placedTowerCount; i++)
            {
                bufferKillCount -= 4 + i * (i + 1);
            }

            int killsRemaining = 0;
            if (placedTowerCount >= 1)
            {
                killsRemaining = 4 + placedTowerCount * (placedTowerCount + 1);
            }

            text.text = killsRemaining <= 0 ? "You can place a unit" : $"{killsRemaining - bufferKillCount} kills remaining";
        }
    }
}
