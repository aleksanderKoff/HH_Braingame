using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileText : MonoBehaviour
{
     private TextMeshProUGUI text;
     PlayerMovement move;
     GameObject player;
     ReactionProblem randomizer;
     string[] values;

     bool direction; // true = dodge left, false = dodge right

     //Convert string to KeyCode
    KeyCode Convert(string key)
    {
        KeyCode keyCode = (KeyCode) System.Enum.Parse(typeof(KeyCode), key);
        return keyCode;
    }

    void Start()
    {
        direction = (Random.value < 0.5); //random between "true" and "false"
        player = GameObject.FindGameObjectWithTag("Player");

        randomizer = player.GetComponent<ReactionProblem>();
        move = player.GetComponent<PlayerMovement>();
        text = GetComponent<TextMeshProUGUI>();

        values = randomizer.AbcRandomizer(); //get random character
        text.text = values[1]; //add random character to projectile
    }

    void Update()
    {
        Boundaries(); //check if player is within boundaries
        DodgeProjectile(direction);
    }

    void Boundaries()
    {
        if (player) { 
            if (player.transform.position.x < 559.0f) //dodge right if player is close to x position 559.0f
            {
                direction = false;
            }
            if (player.transform.position.x > 570.0f) //dodge left if player is close to x position 570.0f
            {
                direction = true;
            }
        }
    }

    void DodgeProjectile(bool direction)
    {
        if (Input.GetKeyDown(Convert(values[1])) && direction == true) 
        {
            move.DodgeLeft();
            Debug.Log("Dodged");
        }
        if (Input.GetKeyDown(Convert(values[1])) && direction == false)
        {
            move.DodgeRight();
            Debug.Log("Dodged");
        }
    }

    
}
