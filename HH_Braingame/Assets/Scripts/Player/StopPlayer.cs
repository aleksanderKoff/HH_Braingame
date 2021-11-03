using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject projectileSpawner;
    drop_projectile projectileDropper;

    public GameObject projectile;

    void Start()
    {
        projectileDropper = projectileSpawner.GetComponent<drop_projectile>();
        projectile.GetComponent<DestroyProjectile>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FreezePlayer") //stop player movement on trigger
        {
            Debug.Log("Freeze player");
            projectileDropper.Initiate();
            player.GetComponent<PlayerMovement> ().enabled = false; //disable PlayerMovement script
            if (projectile != null)
            {
                projectile.GetComponent<DestroyProjectile>().enabled = true; //enable DestroyProjectile script
            }
            
        }
    }
}
