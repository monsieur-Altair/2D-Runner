using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPscore : MonoBehaviour
{
    Text scoreUI;
    int score = 3;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            UpdateScore();
        }

    }
    void UpdateScore()
    {
        scoreUI.text = score.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreUI = GetComponent<Text>();
    }
}
