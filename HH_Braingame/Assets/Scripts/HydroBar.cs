using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HydroBar : MonoBehaviour
{
    Image timerBar;
    public float maxTime = 15;
    HydrationManager hydrationManager;

    // Start is called before the first frame update
    void Start()
    {
        timerBar = GetComponent<Image>();
        hydrationManager = GameObject.FindGameObjectWithTag("Score").GetComponent<HydrationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hydrationManager.time > 0)
        {
            timerBar.fillAmount = hydrationManager.time / maxTime;
        }
    }
}
