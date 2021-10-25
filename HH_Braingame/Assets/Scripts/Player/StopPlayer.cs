using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject projectileSpawner;

    void Start()
    {
        GameObject.Find("ProjectileSpawner").GetComponent<drop_projectile>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FreezePlayer")
        {
            player.GetComponent<PlayerMovement> ().enabled = false;
            projectileSpawner.GetComponent<drop_projectile> ().enabled = true;
            Debug.Log(projectileSpawner.GetComponent<drop_projectile> ().enabled);
        }
    }
}
