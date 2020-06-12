using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class operation_script : MonoBehaviour
{
    public char operation = '+';
    private string available_operations = "+x";
    public Text operation_on_screen;

    // Start is called before the first frame update
    void Start()
    {
        operation_on_screen = GetComponent<Text>();
    }

    public void NextOperation()
    {
        operation = available_operations[Random.Range(0, available_operations.Length)];
        operation_on_screen.text = operation.ToString();
    }
}
