using DataStructures.Events;
using GameController;
using UnityEngine;

namespace GameplayController
{
    internal class GameplayController : StateMachine.StateMachine
    {
        // Incoming game events
        [SerializeField] private GameEvent onSelectMap;
        [SerializeField] private GameEvent onFinishMap;
        [SerializeField] private GameEvent onCloseResultScreen;
        [SerializeField] private GameEvent onSelectReward;
        
        // Features
        

        private void Awake()
        {
            onSelectMap.RegisterListener(StartTDGameplay);
            onFinishMap.RegisterListener(ShowResultScreen);
            onCloseResultScreen.RegisterListener(ShowRewardScreen);
            onSelectReward.RegisterListener(ShowWorldOverview);

            InitializeStateMachine(new WorldOverviewState());
        }
        private void StartTDGameplay()
        {
            TransitionTo(new TDGameplayState());
        }

        private void ShowResultScreen()
        {
            TransitionTo(new RoundResultScreenState());
        }
        
        private void ShowRewardScreen()
        {
            TransitionTo(new RewardScreenState());
        }


        private void ShowWorldOverview()
        {
            TransitionTo(new WorldOverviewState());
        }
    }
}