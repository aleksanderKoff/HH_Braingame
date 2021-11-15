using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    Player player;
    public int fallBoundary = -20;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        //if player falls below boundary, call Respawn function
        if (transform.position.y <= fallBoundary)
        {
            RespawnPlayer();
        }
    }

   void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            Debug.Log("Checkpoint reached!");
            Player.respawnLocation.transform.position = collision.transform.position;
        }
    }

    public static void RespawnPlayer()
    {
        // Changes player position to respawn position (moves player)
        Player.playerLocation.transform.position = new Vector3(Player.respawnLocation.transform.position.x, Player.respawnLocation.transform.position.y, Player.playerLocation.transform.position.z);
        BGMManager.ChangeBgm("Default");  
    }

}
