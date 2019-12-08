using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumPage : MonoBehaviour
{

    public Image BGM_Volum, EFFECT_Volum;
    public Sprite[] volumStatus;
    int bgmVol = 3, effectVol = 3;

    GameObject AudioManager;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager = GameObject.Find("AudioManager");

        // 나중에 볼륨 상태 저장되고, 그 값을 불러오도록 설정하기
        bgmVol = PlayerPrefs.GetInt("BGMvol",5);
        effectVol = PlayerPrefs.GetInt("EFFvol",5);
        // 플레이어가 설정한 볼륨 크기 상태로 이미지 세팅
        BGM_Volum.sprite = volumStatus[bgmVol];
        EFFECT_Volum.sprite = volumStatus[effectVol];
    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR

        // left 버튼 (bgm 볼륨 다운)
        if (Input.GetKeyDown(KeyCode.LeftArrow) && bgmVol > 0)
        {
            bgmVol--;
            BGM_Volum.sprite = volumStatus[bgmVol];
            print("bgmVol : " + bgmVol);
            PlayerPrefs.SetInt("BGMvol", bgmVol);
            AudioManager.GetComponent<AudioSource>().volume = bgmVol*0.2f;
        }
        // right 버튼 (bgm 볼륨 업)
        else if (Input.GetKeyDown(KeyCode.RightArrow) && bgmVol < 5)
        {
            bgmVol++;
            BGM_Volum.sprite = volumStatus[bgmVol];
            print("bgmVol : " + bgmVol);
            PlayerPrefs.SetInt("BGMvol", bgmVol);
            AudioManager.GetComponent<AudioSource>().volume = bgmVol*0.2f;
        }
        // down 버튼 (effect 볼륨 다운)
        else if (Input.GetKeyDown(KeyCode.DownArrow) && effectVol > 0)
        {
            effectVol--;
            EFFECT_Volum.sprite = volumStatus[effectVol];
            print("effectVol : " + effectVol);
            PlayerPrefs.SetInt("EFFvol", effectVol);
            AudioManager.GetComponent<AudioManage>().SetEffectVol(effectVol);
        }
        // up 버튼 (effect 볼륨 업)
        else if (Input.GetKeyDown(KeyCode.UpArrow) && effectVol < 5)
        {
            effectVol++;
            EFFECT_Volum.sprite = volumStatus[effectVol];
            print("effectVol : " + effectVol);
            PlayerPrefs.SetInt("EFFvol", effectVol);
            AudioManager.GetComponent<AudioManage>().SetEffectVol(effectVol);
        }

#else
        // X 버튼 (bgm 볼륨 다운)
        if (Input.GetKeyDown(KeyCode.JoystickButton2) && bgmVol > 0)
        {
            bgmVol--;
            BGM_Volum.sprite = volumStatus[bgmVol];
            PlayerPrefs.SetInt("BGMvol", bgmVol);
            AudioManager.GetComponent<AudioSource>().volume = bgmVol*0.2f;
        }
        // B 버튼 (bgm 볼륨 업)
        else if (Input.GetKeyDown(KeyCode.JoystickButton1) && bgmVol < 5)
        {
            bgmVol++;
            BGM_Volum.sprite = volumStatus[bgmVol];
            PlayerPrefs.SetInt("BGMvol", bgmVol);
            AudioManager.GetComponent<AudioSource>().volume = bgmVol*0.2f;
        }
        // A 버튼 (effect 볼륨 다운)
        else if (Input.GetKeyDown(KeyCode.JoystickButton0) && effectVol > 0)
        {
            effectVol--;
            EFFECT_Volum.sprite = volumStatus[effectVol];
            PlayerPrefs.SetInt("EFFvol", effectVol);
            AudioManager.GetComponent<AudioManage>().SetEffectVol(effectVol);
        }
        // Y 버튼 (effect 볼륨 업)
        else if (Input.GetKeyDown(KeyCode.JoystickButton3) && effectVol < 5)
        {
            effectVol++;
            EFFECT_Volum.sprite = volumStatus[effectVol];
            PlayerPrefs.SetInt("EFFvol", effectVol);
            AudioManager.GetComponent<AudioManage>().SetEffectVol(effectVol);
        }
#endif
    }

}
