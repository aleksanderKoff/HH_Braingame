using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
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

    public static void DestroyObject(GameObject go, float time)
    {
        Destroy(go, time);
    }

    public void Itemfeedback(GameObject go)
    {
        go.anim.SetBool("Clicked", true);
    }
    
}
