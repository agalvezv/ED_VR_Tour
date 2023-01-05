using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

namespace timer_class_test {
    public class Loading : MonoBehaviour
    {
        public static Timer aTmr = new Timer(500);   //1000 ms = 1 second
        public static int secondsCount = 0;
        //public ProgressBar bar;
        public UnityEngine.UI.Slider slider; 
        float totalSceneProgress = 0;
        public TextMeshProUGUI progress;

        // Start is called before the first frame update
        void Start()
        {
            aTmr.Elapsed += ATmr_Elapsed;
            aTmr.Enabled = true;
            aTmr.AutoReset = true;
            aTmr.Start();
            Console.ReadKey();
        }

        private void ATmr_Elapsed(object sender, ElapsedEventArgs e)
        {
            secondsCount++;
            Console.WriteLine(secondsCount + " Seconds");
            Debug.Log(secondsCount + " Seconds");
            if (secondsCount == 4) { totalSceneProgress = 0.05f; }
            if (secondsCount == 5) { totalSceneProgress = 0.09f; }
            if (secondsCount == 6) { totalSceneProgress = 0.16f; }
            if (secondsCount == 7) { totalSceneProgress = 0.29f; }
            if (secondsCount == 9) { totalSceneProgress = 0.35f; }
            if (secondsCount == 12) { totalSceneProgress = 0.47f; }
            if (secondsCount == 13) { totalSceneProgress = 0.55f; }
            if (secondsCount == 15) { totalSceneProgress = 0.64f; }
            if (secondsCount == 16) { totalSceneProgress = 0.71f; }
            if (secondsCount == 17) { totalSceneProgress = 0.80f; }
            if (secondsCount == 19) { totalSceneProgress = 0.89f; }
            if (secondsCount == 21) { totalSceneProgress = 1.0f; }
            //slider.value = (float) (totalSceneProgress/100.0);
            Debug.Log(slider.value);
            //throw new System.NotImplementedException();
        }
        public static float percentage = 0;
        private void Update()
        {
            //slider.value = (float)(totalSceneProgress / 100.0);
            slider.value = (float)totalSceneProgress;
            percentage = totalSceneProgress * 100;
            progress.text = percentage + "%";
            Debug.Log(slider.value);
        }
    }
}