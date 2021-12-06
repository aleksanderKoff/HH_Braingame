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
    public static AudioClip MainMenuBGM;

    public static BGMManager BgmInstance;
  
    private void Awake()
    {
       
        if (BgmInstance == null)
            BgmInstance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        Audio = GetComponent<AudioSource>();

        DefaultBGM = Resources.Load<AudioClip>("Audio/DefaultBGM");
        BossDialogueBGM = Resources.Load<AudioClip>("Audio/BossDialogueBGM");
        BossFightBGM = Resources.Load<AudioClip>("Audio/BossFightBGM");
        VictoryBGM = Resources.Load<AudioClip>("Audio/VictoryBGM");
        MainMenuBGM = Resources.Load<AudioClip>("Audio/MainMenuTheme");
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

        if (Audio && Audio.clip)    {
            switch (bgmName)
            {
                case "Default":
                    Audio.clip = DefaultBGM;
                    Audio.loop = true;
                    break;
                case "BossDialogue":
                    Audio.clip = BossDialogueBGM;
                    Audio.loop = true;
                    break;
                case "BossFight":
                    Audio.clip = BossFightBGM;
                    Audio.loop = true;
                    break;
                case "MainMenu":
                    Audio.clip = MainMenuBGM;
                    Audio.loop = true;
                    break;
                case "VictoryBGM":
                    Audio.clip = VictoryBGM;
                    Audio.loop = false;
                    break;
            }

            Audio.Play();
        }


    }

}