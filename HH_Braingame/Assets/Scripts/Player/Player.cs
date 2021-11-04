using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int fallBoundary = -20;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= fallBoundary)
            GameMaster.KillPlayer(this);
        
    }
    void OnTriggerEnter2D(Collider2D collision) //kill player if hit by projectile
    {
        if (collision.tag == "Projectile")
        {
            GameMaster.KillPlayer(this);
        }
    }
}
