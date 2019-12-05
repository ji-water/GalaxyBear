using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManage : MonoBehaviour
{
    GameObject Listener;
    GameObject AudioManager;

    AudioSource AudioPlay;

    static private float bgmVol =1f; //0~1f 사이
    static private float effetVol =1f;

    //Story
    public AudioClip st_effect1;
    public AudioClip st_effect3;
    public AudioClip st_effect4;

    //Menu
    AudioClip MenuBGM;
    public AudioClip Menu_effect;

    //MainGame
    AudioClip MainBGM;
    public AudioClip Main_skill;
    public AudioClip Main_skill_ch;
    public AudioClip Main_item;
    public AudioClip Main_GMover;
    public AudioClip Main_fireball;
    public AudioClip Main_fireball_fall;


    void Start()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        AudioPlay = gameObject.GetComponent<AudioSource>(); //audiomanager 오브젝트에 붙음

        //story 
        st_effect1 =Resources.Load<AudioClip>("Sounds/story1_effect");
        st_effect3= Resources.Load<AudioClip>("Sounds/story3_effect");
        st_effect4= Resources.Load<AudioClip>("Sounds/story4_effect");

        //menu
        MenuBGM = Resources.Load<AudioClip>("Sounds/title_bgm");
        Menu_effect = Resources.Load<AudioClip>("Sounds/menu_buttoneffect");

        //main
        MainBGM = Resources.Load<AudioClip>("Sounds/main_bgm");
        Main_skill = Resources.Load<AudioClip>("Sounds/main_skilleffect");
        Main_skill_ch = Resources.Load<AudioClip>("Sounds/main_skillchange");
        Main_item= Resources.Load<AudioClip>("Sounds/main_itemeffect");
        Main_GMover= Resources.Load<AudioClip>("Sounds/main_gameover");
        Main_fireball= Resources.Load<AudioClip>("Sounds/main_fireball");
        Main_fireball_fall = Resources.Load<AudioClip>("Sounds/main_fireball_fall");
    }

    public void bgmPlay()
    {
        bool flag = false;
        AudioPlay.loop = true;

        //bgm play
        switch (SceneManager.GetActiveScene().name)
        {
            case "TitleScene":
                Listener = GameObject.Find("Main Camera");
                AudioPlay.clip = MenuBGM;
                break;
            case "MainScene":
                Listener = GameObject.Find("Main Camera");
                if (AudioPlay.clip == MenuBGM)
                    flag = true;
                AudioPlay.clip = MenuBGM;
                break;
            case "GameScene":
                Listener = GameObject.Find("Main Camera");
                AudioPlay.clip = MainBGM;               
                break;
        }
        if(!flag)
            AudioPlay.Play();
        AudioPlay.volume = bgmVol;
    }

    public void setVol(float b,float e)
    {
        bgmVol = b;
        effetVol = e;
        AudioPlay.volume = bgmVol;
    }

}
