using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionProblemCheck : MonoBehaviour
{
    PlayerMovement move;
    DisplayChallenge display;
    UnityEngine.UI.Button button1;
    UnityEngine.UI.Button button2;
    UnityEngine.UI.Button button3;

    public float timer = 1.75f;

    // Start is called before the first frame update
    void Start()
    {
        // Init jump,  method
        move = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        display = GameObject.FindGameObjectWithTag("Player").GetComponent<DisplayChallenge>();
        //Init buttons
        button1 = GameObject.Find("Button").GetComponent<UnityEngine.UI.Button>();
        button2 = GameObject.Find("Button (1)").GetComponent<UnityEngine.UI.Button>();
        button3 = GameObject.Find("Button (2)").GetComponent<UnityEngine.UI.Button>();
        //Set buttons invisible
        ButtonSetFalse(button1, button2, button3);
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
    // Hide Button objects(1, 2, 3)
    void ButtonSetFalse(UnityEngine.UI.Button a, UnityEngine.UI.Button b, UnityEngine.UI.Button c)
    {
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(false);
    }
    // Show Button objects(1, 2, 3)
    void ButtonSetTrue(UnityEngine.UI.Button a, UnityEngine.UI.Button b, UnityEngine.UI.Button c)
    {
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
        button3.gameObject.SetActive(true);
    }

    //Check if the player hit the collider
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player" && gameObject.tag == "Trigger")
        {
            Debug.Log("COLLIDED");
            StartCoroutine(CheckPress(timer));
        }
    }

    IEnumerator CheckPress(float timer)
    {
        // REFAKTOROI
        string[] ui_values = AbcRandomizer();
        Debug.Log("ui_values:" + ui_values[0] + "(" + ui_values[1] + ")" + ui_values[2]);
        
        while (true)
        {
            //Init success condition
            bool success = false;

            //Check 1st trial
            while (success == false && timer > 0f)
            {
                timer -= Time.deltaTime; // reduce timer 
                // display abc puzzle
                display.Abc_puzzle(ui_values[0], ui_values[2]);
                // Set buttons visible
                ButtonSetTrue(button1, button2, button3);
                success = Input.GetKeyDown(Convert(ui_values[1]));
                yield return null;
            }
            if (success == false)
            {
                Debug.Log("Lost");
                ButtonSetFalse(button1, button2, button3);
                display.Clear();
                yield break;
            }

            //Else success
            Debug.Log("Won");
            move.Jump();
            display.Clear();
            ButtonSetFalse(button1, button2, button3);
            break;
        }
    }
}
