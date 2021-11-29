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


    public static SfxManager Instance
    {
        get
        {
            // if exists directly return
            if (SfxInstance) return SfxInstance;

            // otherwise search it in the scene
            SfxInstance = FindObjectOfType<SfxManager>();

            // found it?
            if (SfxInstance) return SfxInstance;

            // otherwise create and initialize it
            CreateInstance();

            return SfxInstance;
        }
    }


    private void Awake()
    {

        if (SfxInstance == null)
            SfxInstance = this;

        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        Audio = GetComponent<AudioSource>();

        MenuMoveSfx = Resources.Load<AudioClip>("Audio/MenuMoveSFX");
        MenuSuccessSfx = Resources.Load<AudioClip>("Audio/MenuSuccessSFX");
        CanHitSfx = Resources.Load<AudioClip>("Audio/CanSfx");

    }


    [RuntimeInitializeOnLoadMethod]
    private static void CreateInstance()
    {
        // skip if already exists
        if (SfxInstance) return;

       new GameObject(nameof(SfxManager)).AddComponent<SfxManager>();
    }


    public static void TurnVolumeDown()
    {
        Audio.volume = Audio.volume - 0.2f;
    }

    public static void TurnVolumeUp()
    {
        Audio.volume = Audio.volume + 0.2f;
    }

    public static void PlaySound(string SoundName)
    {
        switch(SoundName)
        {
            case "MenuMove":
                Audio?.PlayOneShot(MenuMoveSfx);
                break;
            case "MenuSuccess":
                Audio?.PlayOneShot(MenuSuccessSfx);
                break;
            case "CanHit":
                Audio?.PlayOneShot(CanHitSfx);
                break;
        }
    }
}
