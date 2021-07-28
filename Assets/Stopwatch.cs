using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Stopwatch : MonoBehaviour
{
    private bool stopwatchActive = false;
    private float currentTime;
    public Text currentTimeText;
    

        void Start()
        {
            currentTime = 0;

        }

        private void Update()
        {
            if (stopwatchActive==true)
            {
                currentTime = currentTime + Time.deltaTime;
            }
            TimeSpan time =TimeSpan.FromSeconds(currentTime);
            currentTimeText.text = time.ToString(@"mm\:ss\:fff");
        }

        public void StartStopwatch()
        {
            stopwatchActive = true;
        }

        public void StopStopwatch()
        {
            stopwatchActive = false;
        }
}
