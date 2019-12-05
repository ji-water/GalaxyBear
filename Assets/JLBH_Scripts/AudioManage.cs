using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManage : MonoBehaviour
{
    GameObject Listener;
    GameObject AudioManager;

    AudioSource AudioPlay;

    static private float bgmVol; //0~1f 사이
    static private float effetVol;

    //Story

    //Title
    AudioClip TitleBGM;

    //Menu
    AudioClip MenuBGM;

    //MainGame
    AudioClip MainBGM;

    void Start()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        //bgm
        //MainBGM = Resources.Load<AudioClip>("Sounds/Main/Main_BGM");

        //play
        switch (SceneManager.GetActiveScene().name)
        {
            // case "Story":
            //...
        }
    }

    public void setVol(float b,float e)
    {
        bgmVol = b;
        effetVol = e;
    }
    public void changeVol()
    {
        AudioPlay.volume = bgmVol;
    }
}
