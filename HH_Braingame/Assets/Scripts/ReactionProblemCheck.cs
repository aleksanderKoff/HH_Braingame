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
        move = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        
        display = GameObject.FindGameObjectWithTag("Player").
        GetComponent<DisplayChallenge>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    


    // MyScript script = obj.AddComponent<MyScript>();

    // checks if the player hit the collider
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
        while (true)
        {
            float timer = 1.75f;
            bool success = false;
            while (success == false && timer > 0f)
            {
                timer -= Time.deltaTime; // reduce timer 
                display.DisplayButton("R");
                success = Input.GetKeyDown(KeyCode.R);
                yield return null;
            }
            if (success == false)
            {
                Debug.Log("Lost");
                yield break;
            }
            success = false;
            timer = 1.75f;
            while (success == false && timer > 0f)
            {
                timer -= Time.deltaTime; // reduce timer 
                success = Input.GetKeyDown(KeyCode.V);
                display.DisplayButton("V");
                yield return null;
            }
            if (success == false)
            {
                Debug.Log("Lost");
                yield break;
            }

            Debug.Log("Won");
            move.Jump();
            display.DisplayButton("");
            break;
        }
    }
}
