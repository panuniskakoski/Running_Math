using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        // Koska UI on koodattu typerästi
        int width = 844; // or something else
        int height = 600; // or something else
        bool isFullScreen = false; // should be windowed to run in arbitrary resolution
        int desiredFPS = 60; // or something else

        Screen.SetResolution(width, height, isFullScreen, desiredFPS);

        FindObjectOfType<AudioManager>().Play("menu_music");
    }

    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("button_press");
        StartCoroutine(WaitForStart());
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("button_press");
        StartCoroutine(WaitForQuit());
    }

    public IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }

    public IEnumerator WaitForQuit()
    {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }
}
