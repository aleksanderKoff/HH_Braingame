using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChangeHandler : MonoBehaviour
{
    //SPAGETTIA ATM

    public Text instructionText;
    public Color textColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        instructionText = GetComponent<Text>();
        instructionText.text = "This is my text";
        instructionText.color = textColor;
    }

    // Update is called once per frame
    void Update()
    {
        //Press the space key to change the Text message
        if (Input.GetKey(KeyCode.Space))
        {
            instructionText.color = Color.green;
            instructionText.text = "My text has now changed.";
        }
    }


}
