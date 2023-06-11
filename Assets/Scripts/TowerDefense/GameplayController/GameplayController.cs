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
            gameplayData.OnFlowerTowerDeath.RegisterListener(ShowLossResultScreen);
            gameplayData.OnFinalEnemyKilled.RegisterListener(ShowWinResultScreen);

            InitializeStateMachine(new TDGameplayState(gameplayData, levelSlot));
        }

        private void StartTDGameplay()
        {
            TransitionTo(new TDGameplayState(gameplayData, levelSlot));
        }

        private void ShowWinResultScreen()
        {
            gameplayData.ResultType = ResultType.WIN;
            gameplayData.CurrentLevelIndex++;
            TransitionTo(new RoundResultScreenState(levelResultUiCanvas));
        }


        private void ShowLossResultScreen()
        {
            gameplayData.ResultType = ResultType.LOSE;
            TransitionTo(new RoundResultScreenState(levelResultUiCanvas));
        }
    }
}