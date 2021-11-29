using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    MenuConfirmPanel menuConfirmPanel;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Start()
    {
        menuConfirmPanel = GameObject.Find("PauseMenuCanvas (1)").GetComponent<MenuConfirmPanel>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        menuConfirmPanel.disableConfirmation();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading Menu...");
        BGMManager.ChangeBgm("MainMenu");
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
