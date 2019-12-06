using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text[] score = new Text[5];

    //Audio
    GameObject AudioManager;
    GameObject SoundEffect;
    void Start()
    {
        AudioManager = GameObject.Find("AudioManager");
        AudioManager.GetComponent<AudioManage>().bgmPlay();
        SoundEffect = GameObject.Find("SoundEffect");
        SoundEffect.GetComponent<AudioSource>().clip = AudioManager.GetComponent<AudioManage>().Menu_effect;
    }
    //버튼 사운드
    public void playEffect()
    {
        SoundEffect.GetComponent<AudioSource>().volume = PlayerPrefs.GetInt("EFFvol", 5) *0.2f;
        SoundEffect.GetComponent<AudioSource>().Play();
    }

    //ranking
    public void rankingLoad()
    {
        for(int i=0; i<5; i++)
        {
            score[i].text= "TOP "+(i+1)+" : "+PlayerPrefs.GetInt("score" + i, 0);
        }
    }

    //start
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    //quit
    public void QuitApp()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
