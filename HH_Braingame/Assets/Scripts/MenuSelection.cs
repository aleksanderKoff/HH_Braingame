using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour

{
    private string[] menuStates = new string[] { "new game", "options" };
    private string[] optionsMenuStates = new string[] {"bgm volume", "sfx volume" };
    private int selected = 0;
    

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

        arrowPointer = GameObject.Find("/Canvas/Arrow");
        ArrowInitialPosition = arrowPointer.transform.position;

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

        if (MenuIsFunctional == true)
        {

            Vector3 NewGamePosition = ArrowInitialPosition;
            Vector3 OptionsPosition = ArrowInitialPosition + new Vector3(0, -1f);

            //Keyboard Selection

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SfxManager.PlaySound("MenuMove");

                if (selected < menuStates.Length - 1)
                {
                    selected++;
                    arrowPointer.transform.position = OptionsPosition;
                }
                else
                {
                    selected = 0;
                    arrowPointer.transform.position = NewGamePosition;
                    Debug.Log(menuStates[selected]);
                }

            }else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SfxManager.PlaySound("MenuMove");

                if (selected > 0)
                {
                    selected--;
                    arrowPointer.transform.position = NewGamePosition;
                }
                else
                {
                    selected = menuStates.Length - 1;
                    arrowPointer.transform.position = OptionsPosition;
                }
            }

            if(Input.GetKeyDown(KeyCode.LeftArrow) && ActiveMenuState.Equals("Options"))
            {

            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && ActiveMenuState.Equals("Options"))
            {

            }

                //Mouse Selection

                int layerMask = 1 << LayerMask.NameToLayer("Clickable");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, layerMask);
            
            if (hit.collider != null)
            {
                string menuItemName = hit.collider.gameObject.name;
                Debug.Log(hit.collider.gameObject.name);


                if (menuItemName.Equals("NewGameCollider") && !CurrentMenuState.Equals("new game"))
                {
                    selected = 0;
                    SfxManager.PlaySound("MenuMove");
                    arrowPointer.transform.position = NewGamePosition;
                    MouseIsOnMenuItems = true;

                }
                else if (menuItemName.Equals("OptionsCollider") && !CurrentMenuState.Equals("options"))
                {
                    selected = 1;
                    SfxManager.PlaySound("MenuMove");
                    arrowPointer.transform.position = OptionsPosition;
                    MouseIsOnMenuItems = true;
                }
            }
            else
                MouseIsOnMenuItems = false;
        }
        if (ActiveMenuState.Equals("MainMenu"))
            CurrentMenuState = menuStates[selected];
        else if (ActiveMenuState.Equals("Options"))
            CurrentMenuState = optionsMenuStates[selected];
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
        }
        else if (CurrentMenuState.Equals("options"))
        {
            ActiveMenuState = "Options";
            DefaultMenu.SetActive(false);
            VolumeMenu.SetActive(true);
            SfxManager.PlaySound("MenuMove");
        }
        else if (ActiveMenuState.Equals("Options") && Input.GetKeyDown(KeyCode.Escape))
        {
            VolumeMenu.SetActive(false);
            DefaultMenu.SetActive(true);
            SfxManager.PlaySound("MenuMove");
            ActiveMenuState = "MainMenu";
        }
    }
 }
