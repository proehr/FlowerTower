using DataStructures.Events;
using TowerDefense.GameplayController;
using UnityEngine;

namespace GameController
{
    internal class GameController : StateMachine.StateMachine
    {
        // Incoming game events
        [SerializeField] private GameEvent onStartGameplay;
        [SerializeField] private GameEvent onPause;
        [SerializeField] private GameEvent onResume;
        [SerializeField] private GameEvent onBackToStartScreen;
        [SerializeField] private GameEvent onExit;
        
        // Features
        [SerializeField] private GameObject mainMenuCanvas;
        [SerializeField] private GameObject pauseMenuCanvas;
        [SerializeField] private GameplayController gameplayController;

        private void Awake()
        {
            onStartGameplay.RegisterListener(StartGameplay);
            onPause.RegisterListener(PauseGame);
            onResume.RegisterListener(StartGameplay);
            onBackToStartScreen.RegisterListener(BackToStartScreen);
            onExit.RegisterListener(ExitGame);
            
            InitializeStateMachine(new MainMenuState(mainMenuCanvas));
        }

        private void StartGameplay()
        {
            TransitionTo(new GameplayState(gameplayController));
        }

        private void PauseGame()
        {
            TransitionTo(new PauseMenuState(pauseMenuCanvas));
        }

        private void BackToStartScreen()
        {
            TransitionTo(new MainMenuState(mainMenuCanvas));
        }

        private void ExitGame()
        {
            TransitionTo(new ExitingGameState());
        }
    }
}