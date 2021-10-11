using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
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
                PrintName(hit.collider.gameObject);
                DestroyObject(hit.collider.gameObject);
            }
        }
    }

    private void PrintName(GameObject go)
    {
        Debug.Log(go.name);
    }

    private void DestroyObject(GameObject go)
    {
        Destroy(go);
    }
}
