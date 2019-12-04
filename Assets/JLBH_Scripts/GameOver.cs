using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void GAMEOVER()
    {
        double score = this.GetComponent<ScoreManager>().getScore();
        Debug.Log("score: " + score);

        Time.timeScale = 0;

    }
}
