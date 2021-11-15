using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    BossGrid boss_grid;
    drop_projectile projectileDropper;
    public GameObject projectileSpawner;

    void Start()
    {
        projectile.GetComponent<DestroyProjectile>().enabled = false;
        boss_grid = GameObject.Find("BossGrid").GetComponent<BossGrid>();
        boss_grid.enabled = false;
        Debug.Log(boss_grid.enabled == true);
        projectileDropper = projectileSpawner.GetComponent<drop_projectile>();
        projectileDropper.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FreezePlayer") //stop player movement on trigger
        {
            Debug.Log("Freeze player");
            if (boss_grid)
            {
                boss_grid.enabled = true;
            }
            player.GetComponent<PlayerMovement> ().enabled = false; //disable PlayerMovement script
            if (projectile != null)
            {
                projectile.GetComponent<DestroyProjectile>().enabled = true; //enable DestroyProjectile script
                projectileDropper.enabled = true;
            }
            
        }
    }
}
