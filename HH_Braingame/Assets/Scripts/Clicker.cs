using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Clicker : MonoBehaviour
{
    public float time = 0.5f;
    Cherry cherry;
    HydrationManager hydrationmanager;

    private void Start()
    {
        cherry = GameObject.FindGameObjectWithTag("Cherry").GetComponent<Cherry>();
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
                Cherry.PrintName(hitobject);
                hydrationmanager.addToHydration();
                // cherry.Itemfeedback();
                Cherry.DestroyObject(hitobject, time);
            }
        }
    }

   


}
