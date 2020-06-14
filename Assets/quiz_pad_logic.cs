using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quiz_pad_logic : MonoBehaviour
{
    public bool isSolved = false;
    private bool isDone = false;
    public bool isActive = false;

    Animator anim;
    Animator child_anim;

    BoxCollider2D hitbox;

    public GameObject temp;

    void Start()
    {
        anim = GetComponent<Animator>();  
    }

    void Update()
    {
        if (isSolved && !isDone)
        {
            anim.SetBool("isSolved", true);

            foreach (Transform child in transform)
            {
                if (child.tag == "Obstacle")
                {
                    child.GetComponent<Animator>().SetBool("Activated", true);
                    hitbox = child.GetComponent<BoxCollider2D>();
                    hitbox.enabled = true;
                }

                if (child.tag == "Spike")
                {
                    child.GetComponent<Animator>().SetBool("Activated", true);
                    hitbox = child.GetComponent<BoxCollider2D>();
                    hitbox.enabled = false;
                }

                if (child.tag == "Red")
                {
                    child.GetComponent<Animator>().SetBool("Activated", true);
                    hitbox = child.GetComponent<BoxCollider2D>();
                    hitbox.enabled = false;
                }
            }

            // Makes sure we don't do this more than once
            isDone = true;
        }
    }
}
