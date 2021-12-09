using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTransition : MonoBehaviour
{
    private Camera cam;
    private Vector3 targetPos;
    private GameObject manager;
    public float transitionDuration = 2.5f;
    private float bossCameraSize;

    void Start()
    {
        cam = Camera.main;
        manager = GameObject.Find("BGManager");
        bossCameraSize = 8f;
    }

    void Update()
    {
        
    }
    IEnumerator Transition()
    {
        float t = 0.0f;
        Vector3 startingPos = cam.transform.position;
        targetPos = new Vector3(569.49f, -1.59f, -1f);
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale/transitionDuration);
            cam.transform.position = Vector3.Lerp(startingPos, targetPos, t);
            cam.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, bossCameraSize, transitionDuration);
            yield return 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FreezeCam")
        {
            BGMManager.ChangeBgm("BossDialogue");
            StartCoroutine(Transition());
        }
    }
    
}
