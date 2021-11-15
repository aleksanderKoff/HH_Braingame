using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject respawnUI;
    public static GameObject respawnMenu;
    public GameObject player;
    public static GameObject playerHide;

    private void Start()
    {
        respawnMenu = respawnUI;
        playerHide = player;
    }
    public static void Resume()
    {
        playerHide.SetActive(true);
        Respawn.RespawnPlayer();
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
