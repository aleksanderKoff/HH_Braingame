using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{

    public GameObject victoryMenuUI;

    public void LoadPanel()
    {
        victoryMenuUI.SetActive(true);
    }
    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
        BGMManager.ChangeBgm("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
