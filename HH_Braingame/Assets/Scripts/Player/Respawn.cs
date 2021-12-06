using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    Player player;
    public int fallBoundary = -20;

    GameMaster gameMaster;

    Button button1;
    Button button2;
    Button button3;

    ReactionProblem reactionProblem;
    ControllerCamera camControl;
    drop_projectile dropProjectile;
    BossClicker bossClicker;
    Clicker clicker;
    HydrationManager hydrationManager;
    BossGrid bossGrid;
    Camera cam;
    public Slider bossHealth;
    PlayerMovement playerMovement;

    void Start()
    {
        gameMaster = GameObject.Find("GameMaster")?.GetComponent<GameMaster>();

        button1 = gameMaster.Button1;
        button2 = gameMaster.Button2;
        button3 = gameMaster.Button3;

        reactionProblem = gameMaster.ReactionProblem;

        player = gameMaster.Player;
        hydrationManager = gameMaster.HydrationManager;
        camControl = gameMaster.CamControl;
        dropProjectile = gameMaster.DropProjectile;
        bossClicker = gameMaster.BossClicker;
        clicker = gameMaster.Clicker;
        hydrationManager = gameMaster.HydrationManager;
        bossGrid = gameMaster.BossGrid;
        cam = Camera.main;
        playerMovement = gameMaster.PlayerMovement;
    }

    void Update()
    {
        //if player falls below boundary, call Respawn function
        if (transform.position.y <= fallBoundary)
        {
            RespawnMenu.Pause();
            hydrationManager.time = 15;
        }
    }

   void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            Debug.Log("Checkpoint reached!");
            Player.respawnLocation.transform.position = collision.transform.position;
        }
    }

    public void RespawnPlayer()
    {
        // Changes player position to respawn position (moves player)
        Player.playerLocation.transform.position = new Vector3(
            Player.respawnLocation.transform.position.x, 
            Player.respawnLocation.transform.position.y, 
            Player.playerLocation.transform.position.z
        );

        reactionProblem.ButtonSetFalse(button1, button2, button3);

        hydrationManager.time = 15;
        camControl.enabled = true;
        dropProjectile.enabled = false;
        bossHealth.gameObject.SetActive(false);
        bossGrid.enabled = false;
        bossClicker.enabled = false;
        clicker.enabled = true;
        playerMovement.enabled = true;

        cam.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 6f, 2f);

        BGMManager.ChangeBgm("Default");
        BossHealth.ResetHealth();
    }

}
