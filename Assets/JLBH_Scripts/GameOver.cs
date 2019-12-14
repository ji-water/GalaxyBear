using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameover_canvas;
    public GameObject canvas;
    public GameObject Gun;
    public GameObject PauseManager; //gameover되면 pause 입력 막아야함

    public Text ending;
    public Text S;
    public Text bestS;
    AudioManage AM;

    //Audio
    GameObject AudioManager;
   
    public rockManager[] rockTrap = new rockManager[7];
    public AudioSource ItemManager;
    AudioSource thisAudio;

    public GameObject health;

    void Start()
    {

        gameover_canvas.SetActive(false);

        //effect vol
        float vol = PlayerPrefs.GetInt("EFFvol", 5) * 0.2f;

        //bgmplay
        AudioManager = GameObject.Find("AudioManager");
        AM = AudioManager.GetComponent<AudioManage>();
        AM.bgmPlay();

        thisAudio = GetComponent<AudioSource>();
        thisAudio.clip = AM.Main_skill;
        thisAudio.loop = true;
        thisAudio.volume = vol;
        thisAudio.Play();

        //rock sound
        for (int i = 0; i < 7; i++)
        {
            rockTrap[i].explosion.GetComponent<AudioSource>().volume = vol;
            rockTrap[i].rockObj.GetComponent<AudioSource>().volume = vol;
        }

        //item sound
        ItemManager.volume = vol;

    } 

    public void GAMEOVER(bool gameover)
    {
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
        health.SetActive(false);

        thisAudio.loop = false;
        AudioSource AM_Source = AudioManager.GetComponent<AudioSource>();
        AM_Source.clip = AM.Main_GMover;
        AM_Source.loop = false;
        AM_Source.Play();

        double score = this.GetComponent<ScoreManager>().getScore();

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
            if (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.X)){
                pressed = true;
                SceneManager.LoadScene("MainScene");
            }
            //Y button
            if (Input.GetKeyDown(KeyCode.JoystickButton3) || Input.GetKeyDown(KeyCode.Y))
            {
                pressed = true;
                SceneManager.LoadScene("GameScene");
            }
            yield return null;
        }
    }
}
