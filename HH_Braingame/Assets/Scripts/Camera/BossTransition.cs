using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTransition : MonoBehaviour
{
    public Transform cam;
    private Vector3 targetPos;
    public float transitionDuration = 2.5f;
    IEnumerator Transition()
    {
        float t = 0.0f;
        Vector3 startingPos = transform.position;
        targetPos = new Vector3(569.49f, -1.59f, -1f);
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale/transitionDuration);
            transform.position = Vector3.Lerp(startingPos, targetPos, t);
            yield return 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FreezeCam")
        {
            StartCoroutine(Transition());
        }
    }
    
}
