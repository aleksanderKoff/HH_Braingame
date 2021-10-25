using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] public Text score;
    public int scoreAmount = 0;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + scoreAmount;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreAmount;
    }

    public void addToScore()
    {
        scoreAmount += 10;
    }

}
