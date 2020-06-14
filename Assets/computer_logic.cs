using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class computer_logic : MonoBehaviour
{
    public bool next_calc = true;
    public GameObject digit_1;
    public GameObject operation;
    public GameObject digit_2;
    public GameObject result;

    public GameObject player;
    public GameObject active_quiz_pad;
    public Vector3 CheckPointPos;

    public int digit_1_int = 0;
    public char operation_char;
    public int digit_2_int = 0;

    public string player_input = "0";
    public int right_answer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");


        digit_1 = GameObject.Find("Digit_1");
        operation = GameObject.Find("Operation");
        digit_2 = GameObject.Find("Digit_2");
        result = GameObject.Find("Result");
    }

    // Update is called once per frame
    void Update()
    {
        ListenPlayerInput();
    }

    // Command computer components to change by random
    public void NextCalc()
    {
        digit_1.SendMessage("NextDigit");
        operation.SendMessage("NextOperation");
        digit_2.SendMessage("NextDigit");
        result.SendMessage("EmptyResult");
    }
    
    // If player is on a quiz pad
    public void Calculate_right_answer()
    {
        if (player.GetComponent<player_math>().on_quiz_pad)
        {
            digit_1_int = digit_1.GetComponent<digit_script>().digit;
            digit_2_int = digit_2.GetComponent<digit_script>().digit;

            operation_char = operation.GetComponent<operation_script>().operation;
            // Check the operator and calculate result according to that
            // This could be done better for sure...
            if (operation_char == 'x')
            {
                right_answer = digit_1_int * digit_2_int;
            }
            if (operation_char == '-')
            {
                right_answer = digit_1_int - digit_2_int;
            }
            if (operation_char == '+')
            {
                right_answer = digit_1_int + digit_2_int;
            }

            // Now we have the right answer. Let's record player input next.

        }
    }

    public void ListenPlayerInput()
    {
        // Check if player is on quiz pad
        if (player.GetComponent<player_math>().on_quiz_pad)
        {

            active_quiz_pad = GameObject.Find(player.GetComponent<player_math>().current_pad.name);
        }

        // Input allowed only if player is on quiz pad && that quiz pad has not been solved.
        if (player.GetComponent<player_math>().on_quiz_pad && !active_quiz_pad.GetComponent<quiz_pad_logic>().isSolved)
        {
            // What happens when player is on quiz pad and number on numpad is pressed
            for (int i = 0; i < 10; i++)
            {
                if (Input.GetKeyDown("[" + i + "]"))
                {
                    player_input += i.ToString();
                    Debug.Log("Syöte atm " + player_input);
                    result.GetComponent<Text>().text = int.Parse(player_input).ToString();
                    result.GetComponent<Text>().color = Color.black;
                }
            }

            // What happens when enter is pressed
            if (Input.GetKeyDown("enter"))
            {
                Calculate_right_answer();

                if (int.Parse(player_input) == right_answer)
                {
                    Debug.Log("Oikein oli!");
                    result.GetComponent<Text>().color = Color.green;


                    // Merkkaa uuden check pointin
                    float offsetY = 4.0f;
                    // CheckPointPos = player.GetComponent<player_math>().current_pad.transform.position;
                    CheckPointPos = new Vector3(player.GetComponent<player_math>().current_pad.transform.position.x, 
                                                player.GetComponent<player_math>().current_pad.transform.position.y + offsetY);

                    // Quiz pad is marked as solved
                    active_quiz_pad.GetComponent<quiz_pad_logic>().isSolved = true;

                    // Updates result digit(s)
                    result.GetComponent<Text>().text = right_answer.ToString();

                    // Run computer "correct" animation once
                    // Play sound que RIGHT
                }
                else
                {
                    Debug.Log("Väärin, pelle.");
                    result.GetComponent<Text>().color = Color.red;
                    result.GetComponent<Text>().text = "?";
                    // Run computer "wrong" animation once
                    // Play sound que WRONG
                }

                player_input = "0";
            }


        }
    }
}
