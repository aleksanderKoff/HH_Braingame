using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactionProblemV2 : MonoBehaviour
{
    GameMaster gameMaster;

    PlayerMovement move;
    DisplayChallenge display;

    Button button1;
    Button button2;
    Button button3;

    public float timer = 1.75f;

    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();

        move = gameMaster.Move;
        display = gameMaster.Display;

        button1 = gameMaster.Button1;
        button2 = gameMaster.Button2;
        button3 = gameMaster.Button3;

        //Set buttons invisible
        ButtonSetFalse(button1, button2, button3);
    }

    //Check if the player hit the collider
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player" && gameObject.tag == "Trigger1")
        {
            Debug.Log("COLLIDED");
            StartCoroutine(CheckPress1(timer));
        }
    }

    string[] AbcRandomizer()
    {
        // Lenght 26
        string[] abcArray = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

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
        KeyCode keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), key);
        return keyCode;
    }
    // Hide Button objects(1, 2, 3)
    void ButtonSetFalse(Button a, Button b, Button c)
    {
        a.gameObject.SetActive(false);
        b.gameObject.SetActive(false);
        c.gameObject.SetActive(false);
    }
    // Show Button objects(1, 2, 3)
    void ButtonSetTrue(Button b)
    {
        b.gameObject.SetActive(true);
    }

    IEnumerator CheckPress1(float timer)
    {
        // REFAKTOROI
        string[] ui_values = AbcRandomizer();
        Debug.Log($"ui_values: ( {ui_values[0]} ), WRONG ONES: {ui_values[1]} {ui_values[2]}");

        while (true)
        {
            //Init success condition
            bool success = false;

            //Check 1st trial
            while (success == false && timer > 0f)
            {
                timer -= Time.deltaTime; // reduce timer 
                display.OneCharacter(ui_values[0], 2);
                //Set buttons visible
                ButtonSetTrue(button2);
                success = Input.GetKeyDown(Convert(ui_values[0]));
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
