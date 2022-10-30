using DataStructures.Events;
using GameController;
using LevelSelection;
using UnityEngine;

namespace GameplayController
{
    internal class GameplayController : StateMachine.StateMachine
    {
        // Incoming game events
        [SerializeField] private GameEvent onLevelSelected;
        [SerializeField] private GameEvent onFinishMap;
        [SerializeField] private GameEvent onCloseResultScreen;
        [SerializeField] private GameEvent onSelectReward;
        
        // Features
        [SerializeField] private CurrentLevel_SO currentLevel;
        [SerializeField] private GameObject levelSlot;
        [SerializeField] private GameObject resultScreen;
        [SerializeField] private GameObject rewardScreen;
        [SerializeField] private GameObject worldOverviewSlot;
        

        private void Awake()
        {
            onLevelSelected.RegisterListener(StartTDGameplay);
            onFinishMap.RegisterListener(ShowResultScreen);
            onCloseResultScreen.RegisterListener(ShowRewardScreen);
            onSelectReward.RegisterListener(ShowWorldOverview);

            InitializeStateMachine(new WorldOverviewState(worldOverviewSlot));
        }
        private void StartTDGameplay()
        {
            TransitionTo(new TDGameplayState(levelSlot, currentLevel));
        }

        private void ShowResultScreen()
        {
            TransitionTo(new RoundResultScreenState(resultScreen));
        }
        
        private void ShowRewardScreen()
        {
            TransitionTo(new RewardScreenState(rewardScreen));
        }


        private void ShowWorldOverview()
        {
            TransitionTo(new WorldOverviewState(worldOverviewSlot));
        }
    }
}