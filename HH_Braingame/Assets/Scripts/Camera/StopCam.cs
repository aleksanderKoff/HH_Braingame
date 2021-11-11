using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCam : MonoBehaviour
{
    public GameObject Camera;
    public Transform cam;
    public float transitionDuration = 2.5f;
    

    private Vector3 targetPos;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FreezeCam")
        {
            Camera.GetComponent<cameraController> ().enabled = false;
        }
    }
}
