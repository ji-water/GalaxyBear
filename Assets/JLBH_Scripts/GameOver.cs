using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    GameObject gameover_canvas;
    GameObject canvas;
    GameObject Gun;
    GameObject PauseManager; //gameover되면 pause 입력 막아야함

    public Text ending;
    public Text S;
    public Text bestS;

    //Audio
    GameObject AudioManager;

    private void Start()
    {
        gameover_canvas = GameObject.Find("GameOverCanvas");
        canvas = GameObject.Find("Canvas");
        Gun = GameObject.Find("Gun");
        PauseManager = GameObject.Find("SceneManager");

        gameover_canvas.SetActive(false);

        //bgmplay
        AudioManager = GameObject.Find("AudioManager");
        AudioManager.GetComponent<AudioManage>().bgmPlay();

        gameObject.GetComponent<AudioSource>().clip = AudioManager.GetComponent<AudioManage>().Main_skill;
        gameObject.GetComponent<AudioSource>().loop = true;
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetInt("EFFvol", 1);

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
        Gun.SetActive(false);
        PauseManager.SetActive(false);

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

        S.text = "SCORE: "+score.ToString();
        bestS.text = "BEST SCORE: "+best_score.ToString();

        //버튼 입력받기
        StartCoroutine("WaitKeyInput");
        
    }

    IEnumerator WaitKeyInput()
    {
        bool pressed = false;
        while (!pressed)
        {
            //X button to go main
            if (Input.GetKey(KeyCode.JoystickButton2) || Input.GetKey(KeyCode.X)){
                pressed = true;
                SceneManager.LoadScene("MainScene");
            }
            //Y button
            if (Input.GetKey(KeyCode.JoystickButton3) || Input.GetKey(KeyCode.Y))
            {
                pressed = true;
                SceneManager.LoadScene("GameScene");
            }
            yield return null;
        }
    }
}
