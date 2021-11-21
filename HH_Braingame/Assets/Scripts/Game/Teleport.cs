using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject tp_exit;
    public GameObject player;

    Transform playerPosition;
    Transform exitPosition;

    void Start()
    {
        playerPosition = player.GetComponent<Transform>();

        exitPosition = tp_exit.GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerPosition.position = exitPosition.position;
        }
    }
}
