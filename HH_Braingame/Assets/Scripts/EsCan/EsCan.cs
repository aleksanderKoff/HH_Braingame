using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsCan : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PrintName(GameObject go)
    {
        Debug.Log(go.name);
    }

    public static void DestroyObject(GameObject go)
    {
        // Kills player
        Destroy(go);
    }

    public void Itemfeedback(GameObject go)
    {
        anim.SetTrigger("Clicked");
    }
    
}
