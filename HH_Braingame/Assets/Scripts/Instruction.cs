using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        setActivity();
    }


    private void setActivity()
    {
        if (Input.GetKeyDown(KeyCode.Return) && gameObject.activeSelf == true)
            gameObject.SetActive(false);
    }
}
