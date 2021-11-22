using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Clicker : MonoBehaviour
{
    public float time = 0.1f;
    EsCan esCan;
    HydrationManager hydrationmanager;

    private void Start()
    {
        esCan = GameObject.FindGameObjectWithTag("EsCan").GetComponent<EsCan>();
        hydrationmanager = GameObject.FindGameObjectWithTag("Score").GetComponent<HydrationManager>();
    }
    
    private void Update()
    {

        // Specifies which layer can be hit by raycast
        int layerMask = 1 << LayerMask.NameToLayer("Clickable");

        // Sends raycast from camera to mouse click 
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        // Get collider that raycast hit
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, layerMask);


        

        if (hit.collider != null && hit.collider.gameObject.tag.Equals("EsCan"))
        {
            var hitobject = hit.collider.gameObject;
            CursorManager.ChangeCursorColorHit();  
        }
        else
        {
            CursorManager.ChangeCursorColorDefault();
        }
        //finds the gameobject that the raycast hit
        if (hit.collider != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var hitobject = hit.collider.gameObject;
                    EsCan.PrintName(hitobject);
                    hydrationmanager.addToHydration();
                    // TODO: Exit animation ei toiminnassa
                    // esCan.Itemfeedback();
                    SfxManager.PlaySound("CanHit");
                    hitobject.SetActive(false);
                    //Start can respawn coroutine and set respawn time to 5sec
                    StartCoroutine(RespawnCan(hit.collider, 5));
                }
            }
        //Respawns clicked cans after time given in variable
        IEnumerator RespawnCan(Collider2D hit, int time)
        {
            yield return new WaitForSeconds(time);
            hit.gameObject.SetActive(true);

        }
       
    }

   


}
