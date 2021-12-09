using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    GameMaster gameMaster;


    BossHealth boss;

    public Slider bossHealth;
    public static Transform respawnLocation;
    public static Transform playerLocation;
    [SerializeField] public Transform playerPosition;
    [SerializeField] public Transform respawnPoint;


    void Start()
    {
        gameMaster = GameObject.Find("GameMaster")?.GetComponent<GameMaster>();

        playerLocation = playerPosition;
        respawnLocation = respawnPoint;

        if (GameObject.Find("DestroyProjectile"))
        {
            boss = gameMaster.BossHealth;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //kill player if hit by projectile
        if (collision.tag == "Projectile" && gameObject && boss.killed == false)
        {
            RespawnMenu.Pause();
        }
    }

}
