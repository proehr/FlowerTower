using TMPro;
using TowerDefense.GameplayController;
using UnityEngine;

namespace TowerDefense.UI
{
    public class LevelResultUI : MonoBehaviour
    {
        [SerializeField] private GameplayData_SO gameplayData;
        [SerializeField] private TMP_Text resultText;

        private void OnEnable()
        {
            switch (gameplayData.ResultType)
            {
                case ResultType.WIN:
                    resultText.SetText("You Win!");
                    break;
                case ResultType.LOSE:
                    resultText.SetText("You Lose!");
                    break;
            }
        }
    }
}