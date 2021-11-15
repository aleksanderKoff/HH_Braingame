using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static AudioSource Audio;
    public static AudioClip MenuMoveSfx;
    public static AudioClip MenuSuccessSfx;
    public static AudioClip CanHitSfx;

    public static SfxManager SfxInstance;

    private void Awake()
    {
        Audio = GetComponent<AudioSource>();

       MenuMoveSfx = Resources.Load<AudioClip>("Audio/MenuMoveSFX");       
            
       MenuSuccessSfx = Resources.Load<AudioClip>("Audio/MenuSuccessSFX");
       CanHitSfx = Resources.Load<AudioClip>("Audio/CanSfx");

        if (SfxInstance != null && SfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this);

    }

    public void TurnVolumeDown()
    {
        Audio.volume =- 0.2f;
    }

    public void TurnVolumeUp()
    {
        Audio.volume =+ 0.2f;
    }

    public static void PlaySound(string SoundName)
    {
        switch(SoundName)
        {
            case "MenuMove":
                Audio.PlayOneShot(MenuMoveSfx);
                break;
            case "MenuSuccess":
                Audio.PlayOneShot(MenuSuccessSfx);
                break;
            case "CanHit":
                Audio.PlayOneShot(CanHitSfx);
                break;
        }
    }
}
