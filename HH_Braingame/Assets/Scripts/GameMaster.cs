using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    GameObject boss;

    void Start()
    {
        boss = GameObject.Find("HeadMaster");
    }
    public static void KillPlayer (Player player)
    {
        if (player) { 
            Destroy(player.gameObject);
        }
    }
    public static void KillBoss (GameObject boss)
    {
        if (boss)
        {
            Destroy(boss.gameObject);
        }
    }
}
