using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    GameObject gameover_canvas;
    GameObject canvas;

    public Text ending;
    public Text S;
    public Text bestS;

    //Audio
    GameObject AudioManager;

    private void Start()
    {
        gameover_canvas = GameObject.Find("GameOverCanvas");
        canvas = GameObject.Find("Canvas");

        gameover_canvas.SetActive(false);

        //bgmplay
        AudioManager = GameObject.Find("AudioManager");
        AudioManager.GetComponent<AudioManage>().bgmPlay();

        gameObject.GetComponent<AudioSource>().clip = AudioManager.GetComponent<AudioManage>().Main_skill;
        gameObject.GetComponent<AudioSource>().loop = true;
       
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void GAMEOVER(bool gameover)
    {
        Debug.Log("game over");
        if (gameover)
        {
            ending.text = "GAME OVER";
        }
        else
            ending.text = "GAME END";

        gameover_canvas.SetActive(true);
        canvas.SetActive(false);

        gameObject.GetComponent<AudioSource>().loop = false;
        AudioManager.GetComponent<AudioSource>().clip = AudioManager.GetComponent<AudioManage>().Main_GMover;
        AudioManager.GetComponent<AudioSource>().loop = false;
        AudioManager.GetComponent<AudioSource>().Play();

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

        S.text = score.ToString();
        bestS.text = best_score.ToString();
        
    }
}
