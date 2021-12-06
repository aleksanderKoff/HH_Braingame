using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MenuResolution : MonoBehaviour
{
    private static Text textComponent;
    private static Resolution[] resolutions;
    private static int resolutionIndex;
    void Awake()
    {
        resolutions = Screen.resolutions;
        resolutionIndex = 0;
        textComponent = GameObject.Find("VolumeMenu/Resolution").GetComponent<Text>();
        textComponent.text = ResToString(resolutions[resolutionIndex]);
       
    }

    public static void ShowNextResolution()
    {
        if (resolutionIndex < resolutions.Length - 1) 
        { 
            resolutionIndex++;
            textComponent.text = ResToString(resolutions[resolutionIndex]);
        }
        else 
            ShowFirstResolution();

    }
    public static void ShowPreviousResolution()
    {
        if (resolutionIndex > 0)
        {
            resolutionIndex--;
            textComponent.text = ResToString(resolutions[resolutionIndex]);
        }
        else 
            ShowLastResolution();
    }
    public static void ShowFirstResolution()
    {
        
        resolutionIndex = 0;
        textComponent.text = ResToString(resolutions[resolutionIndex]);
    }

    public static void ShowLastResolution()
    {
        resolutionIndex = resolutions.Length - 1;
        textComponent.text = ResToString(resolutions[resolutionIndex]);
    }
    private static string ResToString(Resolution res)
    {
        return res.width + "x" + res.height + " " + res.refreshRate + "hz";
    }
    public static void SetNewResolution()
    {
        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, true);
    }
    
    public static void ShowCurrentResolution()
    {
        List<string> reslist = new List<string>();

        foreach(Resolution res in Screen.resolutions)
        {
            Screen.resolutions.ToList().ForEach(res => reslist.Add(res.ToString()));
            resolutionIndex = Screen.resolutions.ToList().IndexOf(Screen.currentResolution);
        }

        textComponent.text = ResToString(Screen.currentResolution);
    }
}
