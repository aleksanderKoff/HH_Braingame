using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{

    HydrationManager hydrationManager;
    public GameObject victoryMenuUI;
    public GameObject creditsCanvas;

    private void Start()
    {
        hydrationManager = GameObject.Find("Hydration").GetComponent<HydrationManager>();
    }
    public void LoadPanel()
    {
        victoryMenuUI.SetActive(true);
    }
    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
        BGMManager.ChangeBgm("MainMenu");
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }
    public void LoadCredits()
    {
        Debug.Log("Loading credits...");
        creditsCanvas.SetActive(true);
        victoryMenuUI.SetActive(false);
        hydrationManager.enabled = false;
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
