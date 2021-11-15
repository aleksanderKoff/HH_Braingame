using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour

{
    string[] menuStates = new string[] { "new game", "options" };
    int selected = 0;
    Vector3 InitialPosition;
    string CurrentMenuState;
    string menuItemName;
    bool MouseIsOnMenuItems;
    bool MenuIsFunctional;
    bool SuccessSoundHasBeenPlayed;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        pm.moveSpeed = 0;
        InitialPosition = transform.position;
        CurrentMenuState = menuStates[0];
        MouseIsOnMenuItems = false;
        MenuIsFunctional = true;
        SuccessSoundHasBeenPlayed = false;
    }

    void Update()
    {
        CurrentMenuState = ChangeMenuState();

        if(Input.GetKeyDown(KeyCode.Return) || (MouseIsOnMenuItems && Input.GetMouseButton(0)))
            StartCoroutine("ChangeScene", CurrentMenuState);
    }
    private string ChangeMenuState()
    {
        if (MenuIsFunctional == true)
        {

            Vector3 NewGamePosition = InitialPosition;
            Vector3 OptionsPosition = InitialPosition + new Vector3(0, -1f);

            //Keyboard Selection

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SfxManager.PlaySound("MenuMove");

                if (selected < menuStates.Length - 1)
                {
                    selected++;
                    transform.position = OptionsPosition;
                    Debug.Log(menuStates[selected]);
                    Debug.Log(transform.position);
                }
                else
                {
                    selected = 0;
                    transform.position = NewGamePosition;
                    Debug.Log(menuStates[selected]);
                }

            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SfxManager.PlaySound("MenuMove");

                if (selected > 0)
                {
                    selected--;
                    transform.position = NewGamePosition;
                    Debug.Log(menuStates[selected]);
                }
                else
                {
                    selected = menuStates.Length - 1;
                    transform.position = OptionsPosition;
                    Debug.Log(menuStates[selected]);
                }
            }

            //Mouse Selection

            int layerMask = 1 << LayerMask.NameToLayer("Clickable");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, layerMask);


            if (hit.collider != null)
            {
                menuItemName = hit.collider.gameObject.name;
                Debug.Log(hit.collider.gameObject.name);


                if (menuItemName.Equals("NewGameCollider") && !CurrentMenuState.Equals("new game"))
                {
                    selected = 0;
                    SfxManager.PlaySound("MenuMove");
                    transform.position = NewGamePosition;
                    MouseIsOnMenuItems = true;

                }
                else if (menuItemName.Equals("OptionsCollider") && !CurrentMenuState.Equals("options"))
                {
                    selected = 1;
                    SfxManager.PlaySound("MenuMove");
                    transform.position = OptionsPosition;
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
            if (SuccessSoundHasBeenPlayed == false)
            {
                SfxManager.PlaySound("MenuSuccess");
                SuccessSoundHasBeenPlayed = true;
            }
            Debug.Log("played sound");
            pm.moveSpeed = 5;
            MenuIsFunctional = false;

            yield return new WaitForSeconds(3);

            SceneManager.LoadScene("MainMap", LoadSceneMode.Single);
        }

    }
 }
