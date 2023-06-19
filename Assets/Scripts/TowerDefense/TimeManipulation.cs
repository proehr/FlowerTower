using System;
using TowerDefense.Level;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TowerDefense
{
    public class TimeManipulation : MonoBehaviour
    {
        [SerializeField] private GameObject pauseBorder;

        [SerializeField] private float speedOneMultiplier = 1;
        [SerializeField] private float speedTwoMultiplier = 2;
        [SerializeField] private float speedThreeMultiplier = 5;

        private float previousGameSpeed;
        [SerializeField] private bool startGamePaused;

        private Action onEscapeButtonPressed;
        private bool canTakeInput = true;
        private bool isEscaped;

        public Action OnEscapeButtonPressed
        {
            get => onEscapeButtonPressed;
            set => onEscapeButtonPressed = value;
        }

        public void OnEnable()
        {
            if (startGamePaused)
            {
                OnTriggerPause();
            }
            else
            {
                OnSpeedOne();
            }
        }

        public void OnTriggerPause()
        {
            if (canTakeInput)
            {
                if (Time.timeScale == 0)
                {
                    UnpauseGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }

        private void PauseGame()
        {
            previousGameSpeed = Time.timeScale;
            SetGameSpeed(0);
        }
        
        private void UnpauseGame()
        {
            SetGameSpeed(previousGameSpeed);
        }

        public void OnSpeedOne()
        {
            if (canTakeInput)
            {
                SetGameSpeed(speedOneMultiplier);
            }
        }

        public void OnSpeedTwo()
        {
            if (canTakeInput)
            {
                SetGameSpeed(speedTwoMultiplier);
            }
        }

        public void OnSpeedThree()
        {
            if (canTakeInput)
            {
                SetGameSpeed(speedThreeMultiplier);
            }
        }

        private void SetGameSpeed(float speed)
        {
            pauseBorder.SetActive(speed == 0);
            Time.timeScale = speed;
        }

        public void OnTriggerEscape()
        {
            if (isEscaped && Time.timeScale == 0)
            {
                UnpauseGame();
            }
            else if (!isEscaped && Time.timeScale != 0)
            {
                PauseGame();
            }

            canTakeInput = !canTakeInput;
            isEscaped = !isEscaped;
            onEscapeButtonPressed?.Invoke();
        }
    }
}