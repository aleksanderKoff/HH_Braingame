using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCam : MonoBehaviour
{
    GameMaster gameMaster;
    CameraController camControl;

    BossClicker bossClicker;
    Clicker clicker;

    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMaster>();

        camControl = gameMaster.CamControl;

        bossClicker = GameObject.Find("Camera").GetComponent<BossClicker>();
        clicker = GameObject.Find("Camera").GetComponent<Clicker>();
        bossClicker.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FreezeCam")
        {
            camControl.enabled = false;
            clicker.enabled = false;

            bossClicker.enabled = true;
        }
    }
}
