using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Clicker : MonoBehaviour
{
    public float time = 0.5f;
    EsCan esCan;
    HydrationManager hydrationmanager;

    private void Start()
    {
        esCan = GameObject.FindGameObjectWithTag("EsCan").GetComponent<EsCan>();
        hydrationmanager = GameObject.FindGameObjectWithTag("Score").GetComponent<HydrationManager>();
    }
    
    private void Update()
    {


        int layerMask = 1 << LayerMask.NameToLayer("Clickable");
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, layerMask);
            if (hit.collider != null)
            {
                var hitobject = hit.collider.gameObject;
                EsCan.PrintName(hitobject);
                hydrationmanager.addToHydration();
                // cherry.Itemfeedback();
                EsCan.DestroyObject(hitobject, time);
            }
        }
    }

   


}
