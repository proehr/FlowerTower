using TMPro;
using TowerDefense.GameplayController;
using UnityEngine;

namespace TowerDefense.UI
{
    public class LevelResultUI : MonoBehaviour
    {
        [SerializeField] private GameplayData_SO gameplayData;
        [SerializeField] private TMP_Text resultText;
        [SerializeField] private TMP_Text startLevelButtonText;

        private void OnEnable()
        {
            switch (gameplayData.ResultType)
            {
                case ResultType.WIN:
                    resultText.SetText("You Win!");
                    
                    if (gameplayData.CurrentLevelIndex >= gameplayData.LevelPrefabs.Count)
                    {
                        startLevelButtonText.SetText("Restart all levels");
                        gameplayData.CurrentLevelIndex = 0;
                    }
                    else
                    {
                        startLevelButtonText.SetText("Next level");
                    }
                    break;
                case ResultType.LOSE:
                    resultText.SetText("You Lose!");
                    startLevelButtonText.SetText("Retry");
                    break;
            }
        }
    }
}