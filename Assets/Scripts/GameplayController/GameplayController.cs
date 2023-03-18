using DataStructures.Events;
using GameController;
using LevelSelection;
using UnityEngine;

namespace GameplayController
{
    internal class GameplayController : StateMachine.StateMachine
    {
        // Incoming game events
        [SerializeField] private GameEvent onNextRound;
        [SerializeField] private GameEvent onFinishMap;

        // Features
        [SerializeField] private CurrentLevel_SO currentLevel;
        [SerializeField] private GameObject levelSlot;
        [SerializeField] private GameObject resultScreen;

        private void Awake()
        {
            onNextRound.RegisterListener(StartTDGameplay);
            onFinishMap.RegisterListener(ShowResultScreen);

            InitializeStateMachine(new TDGameplayState(levelSlot, currentLevel));
        }
        private void StartTDGameplay()
        {
            TransitionTo(new TDGameplayState(levelSlot, currentLevel));
        }

        private void ShowResultScreen()
        {
            TransitionTo(new RoundResultScreenState(resultScreen));
        }
        
    }
}