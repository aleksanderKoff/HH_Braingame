using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static AudioSource Audio;
    public static AudioClip DefaultBGM;
    public static AudioClip BossDialogueBGM;
    public static AudioClip BossFightBGM;


    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
        DefaultBGM = Resources.Load<AudioClip>("Audio/DefaultBGM");
        BossDialogueBGM = Resources.Load<AudioClip>("Audio/BossDialogueBGM");
        BossFightBGM = Resources.Load<AudioClip>("Audio/BossFightBGM");


    }

    public static void ChangeBgm(string bgmName)
    {

        switch (bgmName)
        {
            case "Default":
                Audio.clip = DefaultBGM;
                break;
            case "BossDialogue":
                Audio.clip = BossDialogueBGM;
                break;
            case "BossFight":
                Audio.clip = BossFightBGM;
                break;
        }

        Audio.Play();


    }

}