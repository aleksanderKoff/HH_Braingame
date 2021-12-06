using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour

{
    private string[] menuStates = new string[] { "new game", "options", "quit" };
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

    private string ArrowPath = "/Canvas/Arrow";

    Vector3 FirstMenuItemPosition;
    Vector3 SecondMenuItemPosition;
    Vector3 ThirdMenuItemPosition;
    Vector3 CurrentArrowPosition;

    void Start()
    {
        FirstMenuItemPosition = GameObject.Find("/Canvas/DefaultMenu/NewGame").transform.position;
        SecondMenuItemPosition = GameObject.Find("/Canvas/DefaultMenu/Options").transform.position;
        ThirdMenuItemPosition = GameObject.Find("/Canvas/DefaultMenu/QuitGame").transform.position;

        player = GameObject.Find("Player");
        pm = player.GetComponent<PlayerMovement>();
        pm.moveSpeed = 0;

        arrowPointer = GameObject.Find("/Canvas/Arrow");
        ArrowInitialPosition = GameObject.Find("/Canvas/ArrowInitialPosition").transform.position;

        MenuVolume.DisplayVolume(BGMManager.Audio.volume, "bgm");
        MenuVolume.DisplayVolume(BGMManager.Audio.volume, "sfx");

        MenuResolution.ShowCurrentResolution();

        VolumeMenu = GameObject.Find("/Canvas/VolumeMenu");
        VolumeMenu.SetActive(false);

        DefaultMenu = GameObject.Find("Canvas/DefaultMenu");
       
        ActiveMenuState = "MainMenu";
        MouseIsOnMenuItems = false;
        MenuIsFunctional = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow));
            ChangeMenuState();

        if(Input.GetKeyDown(KeyCode.Return) || (MouseIsOnMenuItems && Input.GetMouseButtonDown(0)))
            StartCoroutine("ChangeScene");

        if (Input.GetKeyDown(KeyCode.Escape) && !ActiveMenuState.Equals("MainMenu"))
            StartCoroutine("ChangeScene");
    }
    private void ChangeMenuState()
    {
        float menuItemDifferenceX = FirstMenuItemPosition.y - SecondMenuItemPosition.y;
        Vector3 OneStepDown = -(new Vector3(0, menuItemDifferenceX));
        Vector3 OneStepUp = -OneStepDown;
        CurrentArrowPosition = arrowPointer.transform.position;

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
                            MenuVolume.AddVolumeDisplayed("bgm");
                        }
                        else
                        {
                            BGMManager.Audio.volume = 0;
                            MenuVolume.ResetVolumeDisplayedToZero("bgm");
                        }
                        SfxManager.PlaySound("MenuMove");
                    }
                    else if (CurrentMenuState.Equals("sfx volume"))
                    {
                        if (SfxManager.Audio.volume < 1)
                        {
                            SfxManager.TurnVolumeUp();
                            MenuVolume.AddVolumeDisplayed("sfx");

                        }

                        else
                        {
                            SfxManager.Audio.volume = 0;
                            MenuVolume.ResetVolumeDisplayedToZero("sfx");
                        }
                        SfxManager.PlaySound("MenuMove");
                    }
                    else if(CurrentMenuState.Equals("resolution"))
                    {
                                              
                            MenuResolution.ShowNextResolution();
                            SfxManager.PlaySound("MenuMove");
                    }

                }
                //Handle pressing left arrow
                if (Input.GetKeyDown(KeyCode.LeftArrow) && ActiveMenuState.Equals("Options"))
                {
                    if (CurrentMenuState.Equals("bgm volume"))
                    {
                        if (BGMManager.Audio.volume > 0)
                        {
                            BGMManager.TurnVolumeDown();
                            MenuVolume.ReduceVolumeDisplayed("bgm");
                        }
                        else
                        {
                            BGMManager.Audio.volume = 1;
                            MenuVolume.ResetVolumeDisplayedToFull("bgm");
                        }

                        SfxManager.PlaySound("MenuMove");
                    }
                    else if (CurrentMenuState.Equals("sfx volume"))
                    {
                        if (SfxManager.Audio.volume > 0)
                        {
                            SfxManager.TurnVolumeDown();
                            MenuVolume.ReduceVolumeDisplayed("sfx");
                        }
                        else
                        {
                            SfxManager.Audio.volume = 1;
                            MenuVolume.ResetVolumeDisplayedToFull("sfx");
                        }

                        SfxManager.PlaySound("MenuMove");

                    }
                    else if (CurrentMenuState.Equals("resolution"))
                    {
                        MenuResolution.ShowPreviousResolution();
                        SfxManager.PlaySound("MenuMove");
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
            selected = 0;
            SfxManager.PlaySound("MenuMove");
            ActiveMenuState = "MainMenu";
            MenuResolution.SetNewResolution();
            arrowPointer.transform.position = ArrowInitialPosition;
            

        }
        else if (CurrentMenuState.Equals("quit"))
        {
            Debug.Log("Quitting game...");
            Application.Quit();
        }
    }
}
