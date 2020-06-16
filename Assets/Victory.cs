using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public GameObject timer;
    public static string time;

    void Start()
    {
        timer = GameObject.Find("Stopwatch");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            timer.GetComponent<StopWatch>().timerActive = false;
            time = timer.GetComponent<StopWatch>().timerText.text;
            SceneManager.LoadScene(2);
        }
    }
}
