using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTime : MonoBehaviour
{
    public GameObject victory;
    public static string time;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = Victory.time.ToString();
    }
}
