using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManage : MonoBehaviour
{
    GameObject Listener;
    GameObject AudioManager;

    AudioSource AudioPlay;

    //Story
    public AudioClip st_effect1;
    public AudioClip st_effect2;
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
        st_effect2 = Resources.Load<AudioClip>("Sounds/story2_effect");
        st_effect3= Resources.Load<AudioClip>("Sounds/story3_effect");
        st_effect4= Resources.Load<AudioClip>("Sounds/story4_effect");

        //menu
        MenuBGM = Resources.Load<AudioClip>("Sounds/title_bgm");
        Menu_effect = Resources.Load<AudioClip>("Sounds/menu_buttoneffect");

        //main
        MainBGM = Resources.Load<AudioClip>("Sounds/main_bgm");
        Main_skill = Resources.Load<AudioClip>("Sounds/main_skilleffect2");
        Main_skill_ch = Resources.Load<AudioClip>("Sounds/main_skillchange");
        Main_item= Resources.Load<AudioClip>("Sounds/main_itemeffect");
        Main_GMover= Resources.Load<AudioClip>("Sounds/main_gameover");

        AudioPlay.volume = PlayerPrefs.GetInt("BGMvol", 5) * 0.2f; //BGMvol 0~5 정수
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
        AudioPlay.volume = PlayerPrefs.GetInt("BGMvol",5)*0.2f;
    }

/*
    public void SetEffectVol(int vol)
    {
        switch (SceneManager.GetActiveScene().name){
            case "GameScene":
                //enemy sound
               GameObject enemy = GameObject.Find("Desert_Planet/enemy");
                SpawnManage2 spawn_m = enemy.GetComponent<SpawnManage2>();
                for(int i=0; i<spawn_m.enemy.Length; i++)
                {
                    spawn_m.enemy[i].GetComponent<AudioSource>().volume = vol * 0.2f;
                }

                //gun sound
                GameObject GameManager = GameObject.Find("GameManager");
                GameManager.GetComponent<AudioSource>().volume = vol * 0.2f;

                //rock sound
               GameObject[] rockTrap = new GameObject[7];
               for (int i = 0; i < 7; i++)
               {
                    rockTrap[i] = GameObject.Find("rockTrap" + i);
                    rockTrap[i].GetComponent<rockManager>().explosion.GetComponent<AudioSource>().volume = vol * 0.2f;
                    rockTrap[i].GetComponent<rockManager>().rockObj.GetComponent<AudioSource>().volume = vol * 0.2f;
                }

                //item sound
                GameObject ItemManager = GameObject.Find("ItemManager");
                ItemManager.GetComponent<AudioSource>().volume = vol * 0.2f;
                GameObject ItemBox = GameObject.Find("ItemBox");
                ItemBox.GetComponent<AudioSource>().volume = vol * 0.2f;
                break;
        }

    }
    */

}
