using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static AudioSource Audio;
    public static AudioClip DefaultBGM;
    public static AudioClip BossDialogueBGM;
    public static AudioClip BossFightBGM;
    public static AudioClip VictoryBGM;

    public static BGMManager BGMInstance;

    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
        DefaultBGM = Resources.Load<AudioClip>("Audio/DefaultBGM");
        BossDialogueBGM = Resources.Load<AudioClip>("Audio/BossDialogueBGM");
        BossFightBGM = Resources.Load<AudioClip>("Audio/BossFightBGM");
        VictoryBGM = Resources.Load<AudioClip>("Audio/VictoryBGM");

        if (BGMInstance != null && BGMInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this);
    }

    public static void TurnVolumeDown()
    {
        Audio.volume = Audio.volume - 0.2f;
    }

    public static void TurnVolumeUp()
    {
        Audio.volume = Audio.volume + 0.2f;
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
            case "VictoryBGM":
                Audio.clip = null;
                Audio.PlayOneShot(VictoryBGM);
                break;
        }

        Audio.Play();


    }

}