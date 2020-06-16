using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    private Animator start_anim;
    private Animator end_anim;

    private void Start()
    {
        start_anim = GameObject.Find("Start_button").GetComponent<Animator>();
        end_anim = GameObject.Find("End_button").GetComponent<Animator>();
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        start_anim.SetBool("Run", true);
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
        end_anim.SetBool("Run", false);
    }
}
