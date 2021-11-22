using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    ControllerCamera camControl;
    drop_projectile dropProjectile;
    BossHealth boss;
    BossGrid bossGrid;
    BossClicker bossClicker;
    Clicker clicker;
    public Slider bossHealth;
    private Camera cam;
    [SerializeField] public Transform playerPosition;
    [SerializeField] public Transform respawnPoint;
    public static Transform respawnLocation;
    public static Transform playerLocation;
    HydrationManager hydrationManager;

    void Start()
    {
        camControl = GameObject.Find("Camera").GetComponent<ControllerCamera>();
        dropProjectile = GameObject.Find("ProjectileSpawner").GetComponent<drop_projectile>();

        bossClicker = GameObject.Find("Camera").GetComponent<BossClicker>();
        clicker = GameObject.Find("Camera").GetComponent<Clicker>();
        hydrationManager = GameObject.Find("Hydration").GetComponent<HydrationManager>();
        playerLocation = playerPosition;
        respawnLocation = respawnPoint;
        bossGrid = GameObject.Find("BossGrid").GetComponent<BossGrid>();
        cam = Camera.main;
        if (GameObject.Find("DestroyProjectile")) { 
            boss = GameObject.Find("DestroyProjectile").GetComponent<BossHealth>();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //kill player if hit by projectile
        if (collision.tag == "Projectile" && gameObject && boss.killed == false)
        {
            RespawnMenu.Pause();

            hydrationManager.time = 15;
            camControl.enabled = true;
            dropProjectile.enabled = false;
            bossHealth.gameObject.SetActive(false);
            bossGrid.enabled = false;
            bossClicker.enabled = false;
            clicker.enabled = true;

            gameObject.GetComponent<PlayerMovement> ().enabled = true;
            cam.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 6f, 2f);
        }
    }

}
