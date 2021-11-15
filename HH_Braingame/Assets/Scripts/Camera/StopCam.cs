using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCam : MonoBehaviour
{
    public GameObject Camera;
    public Transform cam;
    public float transitionDuration = 2.5f;
    BossClicker bossClicker;
    Clicker clicker;

    private Vector3 targetPos;

    void Start()
    {
        bossClicker = GameObject.Find("Camera").GetComponent<BossClicker>();
        clicker = GameObject.Find("Camera").GetComponent<Clicker>();
        bossClicker.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FreezeCam")
        {
            Camera.GetComponent<cameraController> ().enabled = false;
            bossClicker.enabled = true;
            clicker.enabled = false;
        }
    }
}
