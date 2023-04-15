using TowerDefense.LevelSelection;
using UnityEngine;

namespace TowerDefense.GameplayController
{
    internal class GameplayController : StateMachine.StateMachine
    {
        // Features
        [SerializeField] private GameplayData_SO gameplayData;
        [SerializeField] private GameObject levelSlot;
        [SerializeField] private GameObject levelResultUiCanvas;

        private void Awake()
        {
            gameplayData.OnNextRound.RegisterListener(StartTDGameplay);
            gameplayData.OnFinishMap.RegisterListener(ShowResultScreen);

            InitializeStateMachine(new TDGameplayState(gameplayData, levelSlot));
        }

        private void StartTDGameplay()
        {
            TransitionTo(new TDGameplayState(gameplayData, levelSlot));
        }

        private void ShowResultScreen()
        {
            TransitionTo(new RoundResultScreenState(levelResultUiCanvas));
        }
        
    }
}