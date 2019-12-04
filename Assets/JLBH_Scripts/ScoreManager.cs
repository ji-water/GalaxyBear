using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private double score;

    void Start()
    {
        score = 0;
    }

    //call when monster is killed
    public void scoreUP()
    {
        score += 50; //score 50 per monster (temp)
        scoreText.text = "Score: " + score.ToString();
    }

    public double getScore()
    {
        return score;
    }
}
