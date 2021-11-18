using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StopPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    BossGrid bossGrid;
    drop_projectile projectileDropper;
    public Slider bossHp;
    public GameObject projectileSpawner;

    void Start()
    {
        projectile.GetComponent<DestroyProjectile>().enabled = false;
        bossGrid = GameObject.Find("BossGrid").GetComponent<BossGrid>();
        bossGrid.enabled = false;
        Debug.Log(bossGrid.enabled == true);
        projectileDropper = projectileSpawner.GetComponent<drop_projectile>();
        projectileDropper.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FreezePlayer") //stop player movement on trigger
        {
            Debug.Log("Freeze player");
            if (bossGrid)
            {
                bossGrid.enabled = true;
            }
            bossHp.gameObject.SetActive(true);
            player.GetComponent<PlayerMovement> ().enabled = false; //disable PlayerMovement script
            if (projectile != null)
            {
                projectile.GetComponent<DestroyProjectile>().enabled = true; //enable DestroyProjectile script
                projectileDropper.enabled = true;
            }
            
        }
    }
}
