using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class digit_script : MonoBehaviour
{
    public int digit = 0;
    public Text this_digit;

    private void Start()
    {
        this_digit = GetComponent<Text>();
    }

    // When commanded, changes the digit (range 0-9)
    public void NextDigit()
    {
            digit = Random.Range(0, 10);
            this_digit.text = digit.ToString();
    }
}
