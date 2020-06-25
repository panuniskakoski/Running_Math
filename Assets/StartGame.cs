using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject player;
    public GameObject stopwatch;

    public float timeLeft = 3.0f;
    public Text startText; // used for showing countdown from 3, 2, 1 

    public GameObject countdown;

    private void Start()
    {
        player = GameObject.Find("Player");
        stopwatch = GameObject.Find("Stopwatch");
        FindObjectOfType<AudioManager>().Play("level_music");
    }

    void Update()
    {
        if (GameObject.Find("countdown"))
        {
            timeLeft -= Time.deltaTime;
            startText.text = (timeLeft).ToString("0");
            if (timeLeft < 0)
            {
                FindObjectOfType<AudioManager>().Play("go");
                Destroy(GameObject.Find("countdown"));


                // Start the stopwatch
                stopwatch.GetComponent<StopWatch>().timerActive = true;

                // Releases player movement
                player.gameObject.GetComponent<PlayerMovement>().enabled = true;
            }
        }
    }
}