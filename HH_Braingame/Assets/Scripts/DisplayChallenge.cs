using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayChallenge : MonoBehaviour
{
    [SerializeField] public Text challenge;

    public void DisplayButton(string key)
    {
        challenge.text = key;
    } 
}
