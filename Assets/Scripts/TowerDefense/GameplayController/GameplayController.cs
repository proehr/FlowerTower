using DataStructures.Events;
using TowerDefense.LevelSelection;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TowerDefense.GameplayController
{
    internal class GameplayController : StateMachine.StateMachine
    {
        // Features
        [SerializeField] private GameplayData_SO gameplayData;
        [SerializeField] private GameObject levelSlot;
        [SerializeField] private GameObject levelResultUiCanvas;
        [SerializeField] private GameObject pauseUiCanvas;
        [SerializeField] private TimeManipulation timeManipulation;
        [SerializeField] private Transform cardViewParent;
        [SerializeField] private GameEvent onExitEvent;

        private void Awake()
        {
            gameplayData.OnNextRound.RegisterListener(StartTDGameplay);
            gameplayData.OnFlowerTowerDeath.RegisterListener(ShowLossResultScreen);
            gameplayData.OnFinalEnemyKilled.RegisterListener(ShowWinResultScreen);
            timeManipulation.OnEscapeButtonPressed += ShowPauseScreen;
            onExitEvent.RegisterListener(ExitGame);

            InitializeStateMachine(new TDGameplayState(gameplayData, levelSlot, cardViewParent));
        }

        private void ExitGame()
        {
            Application.Quit();
        }

        private void ShowPauseScreen()
        {
            timeManipulation.OnEscapeButtonPressed -= ShowPauseScreen;
            timeManipulation.OnEscapeButtonPressed += HidePauseScreen;
            pauseUiCanvas.SetActive(true);
        }

        private void HidePauseScreen()
        {
            timeManipulation.OnEscapeButtonPressed -= HidePauseScreen;
            timeManipulation.OnEscapeButtonPressed += ShowPauseScreen;
            pauseUiCanvas.SetActive(false);
        }

        private void StartTDGameplay()
        {
            TransitionTo(new TDGameplayState(gameplayData, levelSlot, cardViewParent));
        }

        private void ShowWinResultScreen()
        {
            gameplayData.ResultType = ResultType.WIN;
            gameplayData.CurrentLevelIndex++;
            TransitionTo(new RoundResultScreenState(levelResultUiCanvas));
            timeManipulation.OnTriggerPause();
        }


        private void ShowLossResultScreen()
        {
            gameplayData.ResultType = ResultType.LOSE;
            TransitionTo(new RoundResultScreenState(levelResultUiCanvas));
            timeManipulation.OnTriggerPause();
        }
    }
}