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
    DialogueTrigger dialogueTrigger;
    HydrationManager hydrationManager;

    void Start()
    {
        projectile.GetComponent<DestroyProjectile>().enabled = false;
        bossGrid = GameObject.Find("BossGrid").GetComponent<BossGrid>();
        bossGrid.enabled = false;
        Debug.Log(bossGrid.enabled == true);
        projectileDropper = projectileSpawner.GetComponent<drop_projectile>();
        projectileDropper.enabled = false;
        dialogueTrigger = GameObject.Find("DialogueTrigger").GetComponent<DialogueTrigger>();
        hydrationManager = GameObject.Find("Hydration").GetComponent<HydrationManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DialogueTrigger" && DialogueManager.DialogueIsOpen == false) //stop player movement on trigger
        {
            player.GetComponent<PlayerMovement>().enabled = false; //disable PlayerMovement script
            dialogueTrigger.TriggerDialogue();

        }
        if (other.tag == "FreezePlayer") {

                player.GetComponent<PlayerMovement>().enabled = false; //disable PlayerMovement script
                hydrationManager.enabled = true;
                Debug.Log("Freeze player");
                if (bossGrid)
                {
                    bossGrid.enabled = true;
                }
                bossHp.gameObject.SetActive(true);
                if (projectile)
                {
                    projectile.GetComponent<DestroyProjectile>().enabled = true; //enable DestroyProjectile script
                    projectileDropper.enabled = true;
                }
            }
        }
}
