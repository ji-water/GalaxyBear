using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    GameObject gameover_canvas;
    GameObject canvas;

    public Text S;
    public Text bestS;

    private void Start()
    {
        gameover_canvas = GameObject.Find("GameOverCanvas");
        canvas = GameObject.Find("Canvas");

        gameover_canvas.SetActive(false);
    }

    public void GAMEOVER()
    {
        double score = this.GetComponent<ScoreManager>().getScore();
        Debug.Log("score: " + score);

        Time.timeScale = 0;

        //베스트 스코어 load
        double best_score = PlayerPrefs.GetInt("bestScore");

        //베스트 스코어 갱신?
        if (best_score < score)
        {
            best_score = score;
            PlayerPrefs.SetInt("bestScore", (int)score);
        }

        //랭킹 스코어 load
        int[] rank = new int[5];
        for(int i=0; i<5; i++)
        {
            rank[i] = PlayerPrefs.GetInt("score" + i, 0);
        }
        //랭킹 스코어 업데이트
        for (int i = 0; i < 5; i++)
        {
            if (rank[i] < score)
            {
                PlayerPrefs.SetInt("score" + i, (int)score);
                for (int j = i + 1; j < 5; j++)
                    PlayerPrefs.SetInt("score" + j, rank[j - 1]);
                break;
            }
        }

        gameover_canvas.SetActive(true);
        canvas.SetActive(false);

        S.text = score.ToString();
        bestS.text = best_score.ToString();
        
    }
}
