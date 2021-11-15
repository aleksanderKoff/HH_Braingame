using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float health = 0;
    public Slider boss_health_slider;
    BossHealth boss_health;
    GameObject boss;
    GameObject spawner;
    [Tooltip("Victory text")]
    public Text victory;
    drop_projectile drop_projectile;
    bool killed;

    void Start()
    {
        boss_health = GameObject.Find("DestroyProjectile").GetComponent<BossHealth>();
        boss = GameObject.Find("HeadMaster");
        drop_projectile = GameObject.Find("ProjectileSpawner").GetComponent<drop_projectile>();
        spawner = GameObject.Find("ProjectileSpawner");
        killed = false;
    }

    // Update is called once per frame
    void Update()
    {
        boss_health_slider.value = health;
        Kill();
    }



    public void ReduceHealth()
    {
        health = health - 20f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            ReduceHealth();
        }
    }
    void Kill()
    {
        if (boss_health.health == 0f && boss_health && killed == false)
        {
            Destroy(spawner);
            victory.text = "Victory!";
            BGMManager.ChangeBgm("VictoryBGM");
            killed = true;
        }
    }
}
