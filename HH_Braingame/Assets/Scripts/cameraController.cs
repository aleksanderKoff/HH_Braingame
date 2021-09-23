using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float yPosRestriction = -20;
    public float HeightModifier = 1;


    private void Update()
    {
        if (player == null)
            return;
        else  
        transform.position = new Vector3(player.position.x, Mathf.Clamp (player.position.y + HeightModifier, yPosRestriction, Mathf.Infinity), transform.position.z);


    }

}
