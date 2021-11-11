using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform checkPoint;
    public int fallBoundary = -20;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        //if player falls below boundary, change player position to respawn position
        if (transform.position.y <= fallBoundary)
        {
            player.transform.position = new Vector3(respawnPoint.transform.position.x, respawnPoint.transform.position.y, player.transform.position.z);
        }


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //kill player if hit by projectile
        if (collision.tag == "Projectile")
        {
            player.transform.position = new Vector3(respawnPoint.transform.position.x, respawnPoint.transform.position.y, player.transform.position.z);
            GameObject.Find("Camera").GetComponent<cameraController>().enabled = true;
            GameObject.Find("ProjectileSpawner").GetComponent<drop_projectile>().enabled = false;
            gameObject.GetComponent<PlayerMovement> ().enabled = true;
            cam.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 6f, 2f);
        }
        //change respawn position to checkpoint when collided
        if (collision.tag == "Checkpoint")
        {
            Debug.Log("Checkpoint reached!");
            
            respawnPoint.transform.position = collision.transform.position;
        }
    }

}
