using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HydrationManager : MonoBehaviour
{
    [SerializeField] public Text hydration;
    public float time = 15;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 0;
        }
        DisplayTime(time);
    }

    public void addToHydration()
    {
        time += 1;
    }

    public void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float seconds = Mathf.FloorToInt(timeToDisplay);
        hydration.text = "Hydration:";
    }

}
