using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HydrationManager : MonoBehaviour
{
    [SerializeField] public Text hydration;
    public float time = 15;
    Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ajastin funktio nesteytykselle
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            if(SceneManager.GetActiveScene().name != "StartMenu") { 
                time = 0;
                GameMaster.KillPlayer(player);
            }
        }
        DisplayTime(time);
    }

    public void addToHydration()
    {
        // Lisää sekunnin
        time += 2;
    }

    public void DisplayTime(float timeToDisplay)
    {
        // Renderöi canvakselle tekstin
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float seconds = Mathf.FloorToInt(timeToDisplay);
        hydration.text = "Hydration:";
    }

}
