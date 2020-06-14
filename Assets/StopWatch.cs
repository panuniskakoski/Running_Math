using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StopWatch : MonoBehaviour
{
    public float startTime;
    public Text timerText;

    public bool timerActive = false;

    private void Start()
    {
        startTime = Time.time + 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            if (float.Parse(minutes) < 10 && float.Parse(seconds) < 10) timerText.text = "0" + minutes + ".0" + seconds;
            else if (float.Parse(seconds) < 10) timerText.text = minutes + ".0" + seconds;
            else timerText.text = "0" + minutes + "." + seconds;
        }
    }
}
