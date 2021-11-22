using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionsStartMenu : MonoBehaviour
{
    Resolution[] resolutions;
    void Start()
    {
        resolutions = Screen.resolutions;
    }



    string ResToString(Resolution res)
    {
        return res.width + "x" + res.height + " " + res.refreshRate + "hz";
    }

    public Resolution[] AvailableResolutions()
    {
        return resolutions;
    }
}
