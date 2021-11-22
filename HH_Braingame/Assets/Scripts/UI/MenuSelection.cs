using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour

{
    private string[] menuStates = new string[] { "new game", "options" };
    private string[] optionsMenuStates = new string[] {"bgm volume", "sfx volume", "resolution" };
    private int selected = 0;
    
    Resolution[] resolutions;
    int resolutionIndex;


    GameObject player;
    PlayerMovement pm;

    private Vector3 ArrowInitialPosition;
    private string CurrentMenuState;
    private string ActiveMenuState;
    private bool MouseIsOnMenuItems;
    private bool MenuIsFunctional;
    private GameObject arrowPointer;

    private GameObject VolumeMenu;
    private GameObject DefaultMenu;

    void Start()
    {
        player = GameObject.Find("Player");
        pm = player.GetComponent<PlayerMovement>();
        pm.moveSpeed = 0;

        resolutions = Screen.resolutions;
        resolutionIndex = 0;

        arrowPointer = GameObject.Find("/Canvas/Arrow");
        ArrowInitialPosition = arrowPointer.transform.position;

        DisplayVolume(BGMManager.Audio.volume, "bgm");
        DisplayVolume(BGMManager.Audio.volume, "sfx");

        VolumeMenu = GameObject.Find("/Canvas/VolumeMenu");
        VolumeMenu.SetActive(false);

        DefaultMenu = GameObject.Find("Canvas/DefaultMenu");

        
        ActiveMenuState = "MainMenu";
        MouseIsOnMenuItems = false;
        MenuIsFunctional = true;
    }
    void Update()
    {
        ChangeMenuState();

        if(Input.GetKeyDown(KeyCode.Return) || (MouseIsOnMenuItems && Input.GetMouseButtonDown(0)))
            StartCoroutine("ChangeScene");

        if (Input.GetKeyDown(KeyCode.Escape) && !ActiveMenuState.Equals("MainMenu"))
            StartCoroutine("ChangeScene");

    }
    private void ChangeMenuState()
    {
        Vector3 OneStepDown = new Vector3(0, -1f);
        Vector3 OneStepUp = new Vector3(0, 1f);
        Vector3 CurrentArrowPosition = arrowPointer.transform.position;

        //Checks whether a new game is already selected or not and if yes doesn't allow to move in the menu
        if (MenuIsFunctional == true)
        {
            //Main Menu
            if (ActiveMenuState.Equals("MainMenu")){
                
                //Handle pressing down arrow
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    SfxManager.PlaySound("MenuMove");

                    if (selected < menuStates.Length - 1)
                    {
                        selected++;
                        arrowPointer.transform.position = CurrentArrowPosition + OneStepDown;
                    }
                    else
                    {
                        selected = 0;
                        arrowPointer.transform.position = ArrowInitialPosition;
                    }
                }

                //Handle pressing up arrow
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    SfxManager.PlaySound("MenuMove");

                    if (selected > 0)
                    {
                        selected--;
                        arrowPointer.transform.position = CurrentArrowPosition + OneStepUp;
                    }
                    else
                    {
                        selected = menuStates.Length - 1;
                        arrowPointer.transform.position = ArrowInitialPosition + (menuStates.Length - 1) * OneStepDown;
                    }
                }
            }
            //Options Menu
            if (ActiveMenuState.Equals("Options"))
            {
                //Handle pressing down arrow
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    SfxManager.PlaySound("MenuMove");

                    if ((ActiveMenuState.Equals("MainMenu") && selected < menuStates.Length - 1) || (ActiveMenuState.Equals("Options") && selected < optionsMenuStates.Length - 1))
                    {
                        selected++;
                        arrowPointer.transform.position = CurrentArrowPosition + OneStepDown;
                    }
                    else
                    {
                        selected = 0;
                        arrowPointer.transform.position = ArrowInitialPosition;
                    }
                }

                //Handle pressing up arrow
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    SfxManager.PlaySound("MenuMove");

                    if (selected > 0)
                    {
                        selected--;
                        arrowPointer.transform.position = CurrentArrowPosition + OneStepUp;
                    }
                    else
                    {
                        selected = optionsMenuStates.Length - 1;
                        arrowPointer.transform.position = ArrowInitialPosition + (optionsMenuStates.Length - 1) * OneStepDown;
                    }
                }

                //Handle pressing right arrow
                if (Input.GetKeyDown(KeyCode.RightArrow) && ActiveMenuState.Equals("Options"))
                {
                    if (CurrentMenuState.Equals("bgm volume"))
                    {
                        if (BGMManager.Audio.volume < 1)
                        {
                            BGMManager.TurnVolumeUp();
                            AddVolumeDisplayed("bgm");
                        }
                        else
                        {
                            BGMManager.Audio.volume = 0;
                            ResetVolumeDisplayedToZero("bgm");
                        }
                        SfxManager.PlaySound("MenuMove");
                    }
                    else if (CurrentMenuState.Equals("sfx volume"))
                    {
                        if (SfxManager.Audio.volume < 1)
                        {
                            SfxManager.TurnVolumeUp();
                            AddVolumeDisplayed("sfx");
                        }

                        else
                        {
                            SfxManager.Audio.volume = 0;
                            ResetVolumeDisplayedToZero("sfx");
                        }
                        SfxManager.PlaySound("MenuMove");
                    }
                    else if(CurrentMenuState.Equals("resolution"))
                    {
                        if(resolutionIndex < resolutions.Length - 1)
                        {
                            ShowNextResolution();
                        }
                        else
                        {
                            ShowFirstResolution();
                        }
                        
                        
                    }

                }
                //handle pressing left arrow
                if (Input.GetKeyDown(KeyCode.LeftArrow) && ActiveMenuState.Equals("Options"))
                {
                    if (CurrentMenuState.Equals("bgm volume"))
                    {
                        if (BGMManager.Audio.volume > 0)
                        {
                            BGMManager.TurnVolumeDown();
                            ReduceVolumeDisplayed("bgm");
                        }
                        else
                        {
                            BGMManager.Audio.volume = 1;
                            ResetVolumeDisplayedToFull("bgm");
                        }

                        SfxManager.PlaySound("MenuMove");
                    }
                    else if (CurrentMenuState.Equals("sfx volume"))
                    {
                        if (SfxManager.Audio.volume > 0)
                        {
                            SfxManager.TurnVolumeDown();
                            ReduceVolumeDisplayed("sfx");
                        }
                        else
                        {
                            SfxManager.Audio.volume = 1;
                            ResetVolumeDisplayedToFull("sfx");
                        }

                        SfxManager.PlaySound("MenuMove");

                    }
                    else if (CurrentMenuState.Equals("resolution"))
                    {
                        if (resolutionIndex > 0)
                        {
                            ShowPreviousResolution();
                        }
                        else
                        {
                            ShowLastResolution();
                        }
                    }
                }
            }
            
            if (ActiveMenuState.Equals("MainMenu"))
                CurrentMenuState = menuStates[selected];
            else if (ActiveMenuState.Equals("Options"))
                CurrentMenuState = optionsMenuStates[selected];            
        }
        
    }

    private IEnumerator ChangeScene()
    {
        
        if (CurrentMenuState.Equals("new game"))
        {
       
            SfxManager.PlaySound("MenuSuccess");
        
            pm.moveSpeed = 5;
            MenuIsFunctional = false;

            yield return new WaitForSeconds(3);

            SceneManager.LoadScene("MainMap", LoadSceneMode.Single);
            BGMManager.ChangeBgm("Default");
        }
        else if (CurrentMenuState.Equals("options"))
        {
            ActiveMenuState = "Options";
            arrowPointer.transform.position = ArrowInitialPosition;
            selected = 0;
            DefaultMenu.SetActive(false);
            VolumeMenu.SetActive(true);
            SfxManager.PlaySound("MenuMove");
        }
        else if (ActiveMenuState.Equals("Options") && Input.GetKeyDown(KeyCode.Escape))
        {
            VolumeMenu.SetActive(false);
            DefaultMenu.SetActive(true);
            arrowPointer.transform.position = ArrowInitialPosition;
            selected = 0;
            SfxManager.PlaySound("MenuMove");
            ActiveMenuState = "MainMenu";
            Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, true);
        }
    }

    private void DisplayVolume(float volume, string type)
    {

        GameObject bgmVolume = GameObject.Find("VolumeMenu/VolumeBGM");
        Text VolumeDisplayBgm = bgmVolume.GetComponent<Text>();
        GameObject sfxVolume = GameObject.Find("VolumeMenu/VolumeSFX");
        Text VolumeDisplaySfx = sfxVolume.GetComponent<Text>();

       
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

    private void AddVolumeDisplayed(string type)
    {
        GameObject bgmVolume = GameObject.Find("VolumeMenu/VolumeBGM");
        Text VolumeDisplayBgm = bgmVolume.GetComponent<Text>();
        GameObject sfxVolume = GameObject.Find("VolumeMenu/VolumeSFX");
        Text VolumeDisplaySfx = sfxVolume.GetComponent<Text>();

        if (type.Equals("bgm"))
            VolumeDisplayBgm.text = VolumeDisplayBgm.text + "I";
        else if (type.Equals("sfx"))
            VolumeDisplaySfx.text = VolumeDisplaySfx.text + "I";
    }

    private void ReduceVolumeDisplayed(string type)
    {
        GameObject bgmVolume = GameObject.Find("VolumeMenu/VolumeBGM");
        Text VolumeDisplayBgm = bgmVolume.GetComponent<Text>();
        GameObject sfxVolume = GameObject.Find("VolumeMenu/VolumeSFX");
        Text VolumeDisplaySfx = sfxVolume.GetComponent<Text>();

        if (type.Equals("bgm"))
            VolumeDisplayBgm.text = VolumeDisplayBgm.text.Remove(VolumeDisplayBgm.text.Length - 1, 1);
        else if (type.Equals("sfx"))
            VolumeDisplaySfx.text = VolumeDisplaySfx.text.Remove(VolumeDisplaySfx.text.Length - 1, 1);
    }
    private void ResetVolumeDisplayedToZero(string type) {

        GameObject bgmVolume = GameObject.Find("VolumeMenu/VolumeBGM");
        Text VolumeDisplayBgm = bgmVolume.GetComponent<Text>();
        GameObject sfxVolume = GameObject.Find("VolumeMenu/VolumeSFX");
        Text VolumeDisplaySfx = sfxVolume.GetComponent<Text>();

        if (type.Equals("bgm"))
            VolumeDisplayBgm.text = "";
        else if (type.Equals("sfx"))
            VolumeDisplaySfx.text = "";
    }

    private void ResetVolumeDisplayedToFull(string type)
    {

        GameObject bgmVolume = GameObject.Find("VolumeMenu/VolumeBGM");
        Text VolumeDisplayBgm = bgmVolume.GetComponent<Text>();
        GameObject sfxVolume = GameObject.Find("VolumeMenu/VolumeSFX");
        Text VolumeDisplaySfx = sfxVolume.GetComponent<Text>();

        if (type.Equals("bgm"))
            VolumeDisplayBgm.text = "IIIII";
        else if (type.Equals("sfx"))
            VolumeDisplaySfx.text = "IIIII";
    }
    private void ShowNextResolution()
    {
        var textComponent = GameObject.Find("VolumeMenu/Resolution").GetComponent<Text>();
        resolutionIndex++;
        textComponent.text = ResToString(resolutions[resolutionIndex]);
    }

    private void ShowPreviousResolution()
    {
        var textComponent = GameObject.Find("VolumeMenu/Resolution").GetComponent<Text>();
        resolutionIndex--;
        textComponent.text = ResToString(resolutions[resolutionIndex]);
    }

    private void ShowFirstResolution()
    {
        var textComponent = GameObject.Find("VolumeMenu/Resolution").GetComponent<Text>();
        resolutionIndex = 0;
        textComponent.text = ResToString(resolutions[resolutionIndex]);
    }

    private void ShowLastResolution()
    {
        var textComponent = GameObject.Find("VolumeMenu/Resolution").GetComponent<Text>();
        resolutionIndex = resolutions.Length - 1;
        textComponent.text = ResToString(resolutions[resolutionIndex]);
    }

    string ResToString(Resolution res)
    {
        return res.width + "x" + res.height + " " + res.refreshRate + "hz";
    }
}
