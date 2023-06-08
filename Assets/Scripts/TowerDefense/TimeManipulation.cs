﻿using UnityEngine;

namespace TowerDefense
{
    public class TimeManipulation : MonoBehaviour
    {
        [SerializeField] private GameObject pauseBorder;

        [SerializeField] private float speedOneMultiplier = 1;
        [SerializeField] private float speedTwoMultiplier = 2;
        [SerializeField] private float speedThreeMultiplier = 5;

        private float previousGameSpeed;

        public void OnTriggerPause()
        {
            if (Time.timeScale == 0)
            {
                SetGameSpeed(previousGameSpeed);
            }
            else
            {
                previousGameSpeed = Time.timeScale;
                SetGameSpeed(0);
            }
        }
        
        public void OnSpeedOne()
        {
            SetGameSpeed(speedOneMultiplier);
        }

        public void OnSpeedTwo()
        {
            SetGameSpeed(speedTwoMultiplier);
        }

        public void OnSpeedThree()
        {
            SetGameSpeed(speedThreeMultiplier);
        }

        private void SetGameSpeed(float speed)
        {
            pauseBorder.SetActive(speed == 0);
            Time.timeScale = speed;
        }
    }
}