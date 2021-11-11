using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEsCanDespawn : MonoBehaviour
{
    public float despawn_timer = 2;
    void Start()
    {
        Destroy(gameObject, despawn_timer);
    }
}
