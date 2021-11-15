using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    private PlayerMovement move;
    private DisplayChallenge display;
    private CameraController camControl;
    GameObject boss;

    private Button button1;
    private Button button2;
    private Button button3;

    public PlayerMovement Move { get => move; set => move = value; }
    public DisplayChallenge Display { get => display; set => display = value; }
    public Button Button1 { get => button1; set => button1 = value; }
    public Button Button2 { get => button2; set => button2 = value; }
    public Button Button3 { get => button3; set => button3 = value; }
    public CameraController CamControl { get => camControl; set => camControl = value; }

    void Awake()
    {
        // Init jump,  method
        Move = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        Display = GameObject.FindGameObjectWithTag("Player").GetComponent<DisplayChallenge>();
        CamControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        boss = GameObject.Find("HeadMaster");
        //Init buttons
        Button1 = GameObject.Find("Button").GetComponent<Button>();
        Button2 = GameObject.Find("Button (1)").GetComponent<Button>();
        Button3 = GameObject.Find("Button (2)").GetComponent<Button>();

    }
    public static void KillPlayer (Player player)
    {
        if (player) { 
            Destroy(player.gameObject);
        }
    }
    public static void KillBoss(GameObject boss)
    {
        if (boss)
        {
            Destroy(boss.gameObject);
        }
    }
}
