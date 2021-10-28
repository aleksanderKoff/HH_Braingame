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
    // Start is called before the first frame update
    void Start()
    {
        Initiate();
    }

    // Update is called once per frame
    public void Initiate()
    {
        InvokeRepeating("Drop", 1.0f, projectile_interval);
        
    }

    public void Drop()
    {
        Quaternion spawnrotation = Quaternion.Euler(0,0,0);
        Instantiate(projectile,drop_position.position,spawnrotation);
    }
    
}
