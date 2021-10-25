using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileText : MonoBehaviour
{
     private TextMeshProUGUI text;
     public ReactionProblemCheck randomizer;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        string[] values = randomizer.AbcRandomizer();
        text.text = values[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
