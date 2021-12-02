using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuVolume : MonoBehaviour
{
    private static GameObject bgmVolume;
    private static Text VolumeDisplayBgm;
    private static GameObject sfxVolume;
    private static Text VolumeDisplaySfx;

    void Awake()
    {
        bgmVolume = GameObject.Find("VolumeMenu/VolumeBGM");
        VolumeDisplayBgm = bgmVolume.GetComponent<Text>();
        sfxVolume = GameObject.Find("VolumeMenu/VolumeSFX");
        VolumeDisplaySfx = sfxVolume.GetComponent<Text>();

    }

    public static void DisplayVolume(float volume, string type)
    {

        switch (volume)
        {
            case 0:
                if (type.Equals("bgm"))
                    VolumeDisplayBgm.text = "";
                else if (type.Equals("sfx"))
                    VolumeDisplaySfx.text = "";
                break;
            case 0.2f:
                if (type.Equals("bgm"))
                    VolumeDisplayBgm.text = "I";
                else if (type.Equals("sfx"))
                    VolumeDisplaySfx.text = "I";
                break;
            case 0.4f:
                if (type.Equals("bgm"))
                    VolumeDisplayBgm.text = "II";
                else if (type.Equals("sfx"))
                    VolumeDisplaySfx.text = "II";
                break;
            case 0.6f:
                if (type.Equals("bgm"))
                    VolumeDisplayBgm.text = "III";
                else if (type.Equals("sfx"))
                    VolumeDisplaySfx.text = "III";
                break;
            case 0.8f:
                if (type.Equals("bgm"))
                    VolumeDisplayBgm.text = "IIII";
                else if (type.Equals("sfx"))
                    VolumeDisplaySfx.text = "IIII";
                break;
            case 1f:
                if (type.Equals("bgm"))
                    VolumeDisplayBgm.text = "IIIII";
                else if (type.Equals("sfx"))
                    VolumeDisplaySfx.text = "IIIII";
                break;
        }
    }
    public static void AddVolumeDisplayed(string type)
    {

        if (type.Equals("bgm"))
            VolumeDisplayBgm.text = VolumeDisplayBgm.text + "I";
        else if (type.Equals("sfx"))
            VolumeDisplaySfx.text = VolumeDisplaySfx.text + "I";
    }

    public static void ReduceVolumeDisplayed(string type)
    {

        if (type.Equals("bgm"))
            VolumeDisplayBgm.text = VolumeDisplayBgm.text.Remove(VolumeDisplayBgm.text.Length - 1, 1);
        else if (type.Equals("sfx"))
            VolumeDisplaySfx.text = VolumeDisplaySfx.text.Remove(VolumeDisplaySfx.text.Length - 1, 1);
    }
    public static void ResetVolumeDisplayedToZero(string type)
    {
        if (type.Equals("bgm"))
            VolumeDisplayBgm.text = "";
        else if (type.Equals("sfx"))
            VolumeDisplaySfx.text = "";
    }

    public static void ResetVolumeDisplayedToFull(string type)
    {

        if (type.Equals("bgm"))
            VolumeDisplayBgm.text = "IIIII";
        else if (type.Equals("sfx"))
            VolumeDisplaySfx.text = "IIIII";
    }


}
