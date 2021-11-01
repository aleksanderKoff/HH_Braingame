using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayChallenge : MonoBehaviour
{
    [SerializeField] public Text letter_1;
    [SerializeField] public Text letter_2;
    [SerializeField] public Text letter_3;
    
    // Sets given character/letter to the assigned position
    // positions: [1] [2] [3] example: [A] [?] [C]
    public void OneCharacter(string character, int position)
    {
        // letter_1: first of the two displayed letters
        if (position == 1)
        {
            letter_1.text = character;
        }
        // letter_2: "?"
        if (position == 2) 
        {
            letter_2.text = character;
        }
        // letter_3: second of the two displayed letters
        if (position == 3)
        {
            letter_3.text = character;
        }
    }

    // runs OneCharacter() for every displayed character/letter to avoid clutter
    public void Abc_puzzle(string firstLetter, string secondLetter)
    {
        OneCharacter(firstLetter, 1);
        OneCharacter("?", 2);
        OneCharacter(secondLetter, 3);
    }

    // clears the text fields
    public void Clear()
    {
        letter_1.text = "";
        letter_2.text = "";
        letter_3.text = "";
    }
}
