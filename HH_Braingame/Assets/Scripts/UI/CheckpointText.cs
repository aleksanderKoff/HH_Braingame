using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointText : MonoBehaviour
{
    public GameObject checkpointText;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            checkpointText.SetActive(true);
            StartCoroutine(ShowText(4));
        }
    }

    IEnumerator ShowText(int time)
    {
        yield return new WaitForSeconds(time);
        checkpointText.SetActive(false);
    }
}
