using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossClicker : MonoBehaviour
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

        // M��ritt�� layerin mihin voi osua raycastill�
        int layerMask = 1 << LayerMask.NameToLayer("Clickable");

        // L�hett�� raycastin Camera:sta mouse clickiin
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        // Hakee colliderin johon raycast osui
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, layerMask);


        

        if (hit.collider != null)
        {
            var hitobject = hit.collider.gameObject;
            CursorManager.ChangeCursorColorHit();  
        }
        else
        {
            CursorManager.ChangeCursorColorDefault();
        }

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
                    EsCan.DestroyObject(hitobject);

                }
            }
       
    }

   


}