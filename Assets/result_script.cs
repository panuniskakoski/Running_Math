using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result_script : MonoBehaviour
{
    public Text result_displayed;

    private void Start()
    {
        result_displayed = GameObject.Find("Result").GetComponent<Text>();
    }

    // When commanded, changes the digit (range 0-9)
    public void EmptyResult()
    {
        result_displayed.text = "?";
        result_displayed.color = Color.red;
    }
}
