using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float yPosRestriction = -20;
    public float heightModifier = 1;
    private float minPositionX = -2f;
    private float maxPositionX = 580f;
    private float minPositionY = -20f;
    private float maxPositionY = 1f;


    private void Update()
    {
        if (player == null)
            return;
        else  
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, minPositionX, maxPositionX), Mathf.Clamp(player.transform.position.y, minPositionY, maxPositionY), transform.position.z);
    }

}
