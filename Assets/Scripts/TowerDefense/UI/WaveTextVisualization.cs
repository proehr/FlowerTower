using System;
using DataStructures.ReactiveVariable;
using TMPro;
using TowerDefense.Level;
using UnityEngine;
using UniRx;

public class WaveTextVisualization : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    
    [Header("Wave Requirement")]
    [SerializeField] private IntReactiveVariable currentStage;
    [SerializeField] private IntReactiveVariable totalStages;
    
    private IDisposable _currentStageDisposable;
    private IDisposable _runtimeSetDisposable;
    
    private void Start()
    {
        _currentStageDisposable = currentStage
            .ObserveEveryValueChanged(x => x.GetValue())
            .Subscribe(x => UpdateKillRequirementText());
        _runtimeSetDisposable = totalStages
            .ObserveEveryValueChanged(x => x.GetValue())
            .Subscribe(x => UpdateKillRequirementText());
    }

    private void OnDestroy()
    {
        _currentStageDisposable.Dispose();
        _runtimeSetDisposable.Dispose();
    }

    private void UpdateKillRequirementText()
    {
        text.text = $"Wave {currentStage.GetValue() + 1} | {totalStages.GetValue()} ";
    }
}
