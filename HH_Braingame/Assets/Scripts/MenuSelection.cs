using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour

{
    string[] menuStates = new string[] { "new game", "options" };
    int selected = 0;
    Vector3 ArrowInitialPosition;
    string CurrentMenuState;
    bool MouseIsOnMenuItems;
    bool MenuIsFunctional;
    GameObject arrowPointer;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        pm.moveSpeed = 0;

        arrowPointer = GameObject.Find("/Canvas/CenterTexts/Arrow");
        ArrowInitialPosition = arrowPointer.transform.position;

        CurrentMenuState = menuStates[0];
        MouseIsOnMenuItems = false;
        MenuIsFunctional = true;
        
    }

    void Update()
    {
        CurrentMenuState = ChangeMenuState();

        if(Input.GetKeyDown(KeyCode.Return) || (MouseIsOnMenuItems && Input.GetMouseButtonDown(0)))
            StartCoroutine("ChangeScene", CurrentMenuState);
    }
    private string ChangeMenuState()
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

            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
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

            //Mouse Selection

            int layerMask = 1 << LayerMask.NameToLayer("Clickable");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, layerMask);
            string menuItemName;


            if (hit.collider != null)
            {
                menuItemName = hit.collider.gameObject.name;
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
            return menuStates[selected];
    }

    private IEnumerator ChangeScene(string CurrentMenuState)
    {
        GameObject player = GameObject.Find("Player");
        PlayerMovement pm = player.GetComponent<PlayerMovement>();

        if (CurrentMenuState.Equals("new game"))
        {
       
            SfxManager.PlaySound("MenuSuccess");
        
            pm.moveSpeed = 5;
            MenuIsFunctional = false;

            yield return new WaitForSeconds(3);

            SceneManager.LoadScene("MainMap", LoadSceneMode.Single);
        }

    }
 }
