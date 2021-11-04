using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChangerScript : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            Debug.Log("nyt osu");
            BGMManager.ChangeBgm("BossDialogue");
        }
    }
}
