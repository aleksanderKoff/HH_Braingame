using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEsCanDespawn : MonoBehaviour
{
    //Despawn cans after 2 seconds during boss fight
    public float despawn_timer = 2;
    void Start()
    {
        Destroy(gameObject, despawn_timer);
    }
}
