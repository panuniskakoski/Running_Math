using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_math : MonoBehaviour
{

    // Kaikki statsit mitä hahmosta tarviaa träkkää
    public bool counting = true;
    public bool ready_with_counting = false;
    public bool on_quiz_pad = false;
    public bool pad_is_solved = false;
    public bool pad_is_active = false;

    public GameObject current_pad = null;
    public GameObject computer;


    // Start is called before the first frame update
    void Start()
    {
        // Player Movement frozen until countdown is 0
        this.gameObject.GetComponent<PlayerMovement>().enabled = false;

        computer = GameObject.Find("Computer");
    }

    // Update is called once per frame
    void Update()
    {

    }


    // Quiz pad control when on a quiz pad
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Quiz_pad"))
        {
            Debug.Log("Quiz pad activated!");
            current_pad = GameObject.Find(other.name);
            pad_is_solved = current_pad.GetComponent<quiz_pad_logic>().isSolved;
            pad_is_active = current_pad.GetComponent<quiz_pad_logic>().isActive;

            // When player arrives at a new quiz pad
            if (!pad_is_active && !pad_is_solved)
            {
                computer.SendMessage("NextCalc");

                // This activates the quiz pad
                current_pad.GetComponent<quiz_pad_logic>().isActive = true;
                on_quiz_pad = true;
            }

            // When player arrives at a unsolved but activated quiz pad
            if (pad_is_active && !pad_is_solved)
            {
                // This activates the quiz pad
                current_pad.GetComponent<quiz_pad_logic>().isActive = true;
                on_quiz_pad = true;
            }


        }
    }

    // Quiz pad control when off a quiz pad
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Quiz_pad"))
        {
            Debug.Log("Pad is no loger active");
            current_pad = GameObject.Find(other.name);
            // current_pad.GetComponent<quiz_pad_logic>().isActive = false;
            on_quiz_pad = false;
        }
    }
}
