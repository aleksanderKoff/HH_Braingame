using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnMenu : MonoBehaviour
{
    GameMaster gameMaster;
    Respawn respawn;
    public static bool GameIsPaused = false;
    public GameObject respawnUI;
    public static GameObject respawnMenu;
    public GameObject player;
    public static GameObject playerHide;

    private void Start()
    {
        gameMaster = GameObject.Find("GameMaster")?.GetComponent<GameMaster>();

        respawn = gameMaster.Respawn;
        respawnMenu = respawnUI;
        playerHide = player;
    }
    public void Resume()
    {
        playerHide.SetActive(true);
        respawn.RespawnPlayer();
        respawnMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public static void Pause()
    {
        playerHide.SetActive(false);
        respawnMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

}
