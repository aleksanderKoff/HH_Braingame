using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactionProblem : MonoBehaviour
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
        gameMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMaster>();

        if (gameMaster) {
            Debug.Log($"{gameMaster} Found!");

            move = gameMaster.Move;
            display = gameMaster.Display;

            button1 = gameMaster.Button1;
            button2 = gameMaster.Button2;
            button3 = gameMaster.Button3;

            //Set buttons invisible
            if (button1 & button2 & button3) { 
                Debug.Log($"Setting buttons false...");
                ButtonSetFalse(button1, button2, button3);
            }
        }
        else
        {
            Debug.LogError($"{gameMaster} not found...");
        }
    }
    

    //Check if the player hit the collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ReactionProblem" && gameObject.tag == "Player")
        {
            Debug.Log($"{gameObject.tag} detected!");
            StartCoroutine(CheckPress(timer));
        }
    }

    public string[] AbcRandomizer()
    {
        string[] abcArray;
        string[] result;
        // Lenght 15
        abcArray = new string[] { "Q", "W", "E", "R", "T", "A", "S", "D", "F", "G", "Z", "X", "C", "V", "B" };

        List<string> draw = new List<string>();

        int arrLenghtAbc = abcArray.Length;

        Debug.Log($"Current array: {abcArray} Array lenght: {arrLenghtAbc}");

        int spaceForLast = 3;
        int lastTwoLetters = 2;
        int arrFirstIndex = 0;

        int maxRandom = arrLenghtAbc - spaceForLast;
        int randomValue = Random.Range(arrFirstIndex, maxRandom);
        int endValue = randomValue + lastTwoLetters;

        draw.Clear();

        while (randomValue <= endValue)
        {
            draw.Add(abcArray[randomValue]);
            randomValue++;
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
    public void ButtonSetFalse(Button a, Button b, Button c)
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

    public IEnumerator CheckPress(float timer)
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
