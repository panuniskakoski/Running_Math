using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Respawn : MonoBehaviour
{
    public GameObject player;
    public GameObject computer;

    private void Start()
    {
        player = GameObject.Find("Player");
        player = GameObject.Find("Computer");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("blanca_silent_nur");
            other.transform.position = computer.GetComponent<computer_logic>().CheckPointPos;
        }
    }
}
