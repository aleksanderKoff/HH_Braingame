using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour


{
    string[] menuStates = new string[] { "new game", "options" };
    int selected = 0;
    Vector3 InitialPosition;
    
     

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        pm.moveSpeed = 0;
        InitialPosition = transform.position;
        

    }

    // Update is called once per frame
    void Update()
    {
        
        string CurrentMenuState = ChangeMenuState();

        if(Input.GetKeyDown(KeyCode.Return))
            StartCoroutine("ChangeScene", CurrentMenuState);

    }

 

    private string ChangeMenuState()
    {
        

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SfxManager.PlaySound("MenuMove");
            Debug.Log("DownArrow");
            
            if (selected < menuStates.Length - 1)
            {
                selected++;
                transform.position = transform.position + new Vector3(0, -115f);
                Debug.Log(menuStates[selected]);
            }
            else
            {
                selected = 0;
                transform.position = InitialPosition;
                Debug.Log(menuStates[selected]);
            }
        }else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SfxManager.PlaySound("MenuMove");

            Debug.Log("UpArrow");
             if (selected > 0)
             {
                 selected--;
                 transform.position = transform.position + new Vector3(0, 115f);
                 Debug.Log(menuStates[selected]);
             }
             else
             {
                 selected = menuStates.Length - 1;
                 transform.position = InitialPosition + new Vector3(0, -115f);
                 Debug.Log(menuStates[selected]);
             }
            
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
            yield return new WaitForSeconds(3);

            SceneManager.LoadScene("MainMap", LoadSceneMode.Single);
        }

    }
 }
