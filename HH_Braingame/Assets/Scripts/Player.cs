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
}
