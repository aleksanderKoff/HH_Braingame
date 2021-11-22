using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCam : MonoBehaviour
{
    GameMaster gameMaster;
    ControllerCamera camControl;

    BossClicker bossClicker;
    Clicker clicker;
    HydrationManager hydrationManager;

    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMaster>();

        camControl = gameMaster.CamControl;

        bossClicker = GameObject.Find("Camera").GetComponent<BossClicker>();
        clicker = GameObject.Find("Camera").GetComponent<Clicker>();
        hydrationManager = GameObject.Find("Hydration").GetComponent<HydrationManager>();
        bossClicker.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FreezeCam")
        {
            camControl.enabled = false;
            clicker.enabled = false;
            hydrationManager.enabled = false;
            bossClicker.enabled = true;
        }
    }
}
