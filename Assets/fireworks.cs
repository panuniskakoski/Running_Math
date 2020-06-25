using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireworks : MonoBehaviour
{
    public GameObject check;
    public bool lit = false;

    // Start is called before the first frame update
    void Start()
    {
        check = GameObject.Find("fireworks");
    }

    // Update is called once per frame
    void Update()
    {
        if (check.GetComponent<Animator>().GetBool("Activated"))
        {
            if (!lit)
            {
                lit = true;
                FindObjectOfType<AudioManager>().Play("fireworks");
            }
        }
    }
}
