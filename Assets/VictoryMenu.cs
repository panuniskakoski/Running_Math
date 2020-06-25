using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    public void RestartRun()
    {
        FindObjectOfType<AudioManager>().Play("button_press");
        StartCoroutine(WaitForRestart());
    }

    public void ToMenu()
    {
        FindObjectOfType<AudioManager>().Play("button_press");
        StartCoroutine(WaitForMenu());
    }

    public IEnumerator WaitForRestart()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }

    public IEnumerator WaitForMenu()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0);
    }
}
