using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public static float health = 100f;
    public float reduceBossHealth = 5f;
    public Slider boss_health_slider;
    BossHealth boss_health;
    GameObject boss;
    GameObject player;
    GameObject spawner;
    GameObject grid;
    BossGrid bossGrid;
    VictoryMenu victoryMenu;
    HydrationManager hydration;
    drop_projectile drop_projectile;
    public bool killed;

    void Start()
    {
        health = 100f;
        bossGrid = GameObject.Find("BossGrid").GetComponent<BossGrid>();
        boss_health = GameObject.Find("DestroyProjectile").GetComponent<BossHealth>();
        boss = GameObject.Find("HeadMaster");
        drop_projectile = GameObject.Find("ProjectileSpawner").GetComponent<drop_projectile>();
        spawner = GameObject.Find("ProjectileSpawner");
        grid = GameObject.Find("BossGrid");
        hydration = GameObject.Find("Hydration").GetComponent<HydrationManager>();
        player = GameObject.Find("Player");
        victoryMenu = GameObject.Find("VictoryCanvas").GetComponent<VictoryMenu>();
        killed = false;
    }

    // Update is called once per frame
    void Update()
    {
        boss_health_slider.value = health;
        Kill();
    }


    private void ReduceHealth()
    {
        health = health - reduceBossHealth;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            ReduceHealth();
        }
    }
    public static void ResetHealth()
    {
            health = 100f;
    }
    void Kill()
    {
        if (health <= 0f && boss_health && killed == false)
        {
            drop_projectile.enabled = false;
            bossGrid.enabled = false;
            victoryMenu.LoadPanel();
            hydration.enabled = false;
            BGMManager.ChangeBgm("VictoryBGM");
            killed = true;
        }
    }
}
