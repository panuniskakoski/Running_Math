using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkey_sound : MonoBehaviour
{
    public bool check = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !check)
        {
            FindObjectOfType<AudioManager>().Play("blanca_silent_hur");
            check = true;
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {

    }
}
