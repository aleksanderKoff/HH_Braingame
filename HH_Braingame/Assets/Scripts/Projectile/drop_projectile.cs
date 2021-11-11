using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class drop_projectile : MonoBehaviour
{

    public GameObject spawner;


    ReactionProblemCheck randomizer;

    public Transform drop_position;

    public float projectile_interval = 2.0f;
    public GameObject projectile;


    public void Initiate() //initiate dropping projectiles
    {
        InvokeRepeating("Drop", 4.5f, projectile_interval);
        
    }

    public void Drop()
    {
        Quaternion spawnrotation = Quaternion.Euler(0,0,0); //prevents projectile from rotating during spawn

        if (projectile && drop_position && gameObject.GetComponent<drop_projectile>().enabled == true)
        { 
            Instantiate(projectile,drop_position.position,spawnrotation);
            Debug.Log("Firing...");
        }

        else
        {
            Debug.Log("Null projectile");
        }

        
    }
    
}
