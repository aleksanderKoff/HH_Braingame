using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StopPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    BossGrid boss_grid;
    drop_projectile projectileDropper;
    public Slider boss_hp;
    public GameObject projectileSpawner;
    DialogueTrigger dialogueTrigger;

    void Start()
    {
        projectile.GetComponent<DestroyProjectile>().enabled = false;
        boss_grid = GameObject.Find("BossGrid").GetComponent<BossGrid>();
        boss_grid.enabled = false;
        Debug.Log(boss_grid.enabled == true);
        projectileDropper = projectileSpawner.GetComponent<drop_projectile>();
        projectileDropper.enabled = false;
        dialogueTrigger = GameObject.Find("DialogueTrigger").GetComponent<DialogueTrigger>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DialogueTrigger") //stop player movement on trigger
        {
            player.GetComponent<PlayerMovement>().enabled = false; //disable PlayerMovement script
            dialogueTrigger.TriggerDialogue();

        }
        if (other.tag == "FreezePlayer") {

                player.GetComponent<PlayerMovement>().enabled = false; //disable PlayerMovement script
                Debug.Log("Freeze player");
                if (boss_grid)
                {
                    boss_grid.enabled = true;
                }
                boss_hp.gameObject.SetActive(true);
                if (projectile != null)
                {
                    projectile.GetComponent<DestroyProjectile>().enabled = true; //enable DestroyProjectile script
                    projectileDropper.enabled = true;
                }
            }
        }
}
