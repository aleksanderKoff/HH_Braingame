using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayChallenge : MonoBehaviour
{
    [SerializeField] public Text challenge;

    public void DisplayButton(string key1, string blank, string key2)
    {
        challenge.text = key1 + blank + key2;
    } 
}
