using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionProblemCheck : MonoBehaviour
{
    PlayerMovement move;
    DisplayChallenge display;

    // Start is called before the first frame update
    void Start()
    {
        // Init jump,  method
        move = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        display = GameObject.FindGameObjectWithTag("Player").GetComponent<DisplayChallenge>();

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    string[] AbcRandomizer()
    {
        // Lenght 26
        string[] abcArray = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

        //Initialize blank list, array
        List<string> draw = new List<string>();
        string[] result;

        int seed = Random.Range(0, 23);
        int end = seed + 2;

        while (seed <= end)
        {
            draw.Add(abcArray[seed]);
            seed++;
        }

        result = draw.ToArray();

        return result;
    }

    //Convert string to KeyCode
    KeyCode Convert(string key)
    {
        KeyCode keyCode = (KeyCode) System.Enum.Parse(typeof(KeyCode), key);
        return keyCode;
    }

    //Check if the player hit the collider
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player" && gameObject.tag == "Trigger")
        {
            Debug.Log("COLLIDED");
            StartCoroutine(CheckPress());
        }
    }

    IEnumerator CheckPress()
    {
        string[] ui_values = AbcRandomizer();
        

        Debug.Log("ui_values1:" + ui_values[0] + "(" + ui_values[1] + ")" + ui_values[2]);
        

        while (true)
        {
            //Init timer, success condition
            float timer = 1.75f;
            bool success = false;

            //Check 1st trial
            while (success == false && timer > 0f)
            {
                timer -= Time.deltaTime; // reduce timer 
                display.DisplayButton(ui_values[0], " _ ", ui_values[2]);
                success = Input.GetKeyDown(Convert(ui_values[1]));
                yield return null;
            }
            if (success == false)
            {
                Debug.Log("Lost");
                yield break;
            }

            //Else success
            Debug.Log("Won");
            move.Jump();
            display.DisplayButton("", "", "");
            break;
        }
    }
}
