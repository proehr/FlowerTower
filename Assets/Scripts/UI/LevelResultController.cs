using System;
using DataStructures.Variables;
using GameplayController;
using LevelSelection;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LevelResultController : MonoBehaviour
    {
        [SerializeField] private GameplayData gameplayData;
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