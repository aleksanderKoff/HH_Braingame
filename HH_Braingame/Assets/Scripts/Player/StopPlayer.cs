using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject projectileSpawner;

    public GameObject projectile;

    void Start()
    {
        GameObject.Find("ProjectileSpawner").GetComponent<drop_projectile>().enabled = false;
        projectile.GetComponent<DestroyProjectile>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FreezePlayer") //stop player movement on trigger
        {
            player.GetComponent<PlayerMovement> ().enabled = false; //disable PlayerMovement script
            projectileSpawner.GetComponent<drop_projectile> ().enabled = true; //start dropping projectiles
            if (projectile != null)
            {
                projectile.GetComponent<DestroyProjectile>().enabled = true; //enable DestroyProjectile script
            }
            
        }
    }
}
