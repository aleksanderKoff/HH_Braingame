using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop_projectile : MonoBehaviour
{

    public Transform drop_position;

    public float projectile_interval = 1.0f;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Drop", 1.0f, projectile_interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drop()
    {
        Quaternion spawnrotation = Quaternion.Euler(0,0,0);
        Instantiate(projectile,drop_position.position,spawnrotation);
    }
}
