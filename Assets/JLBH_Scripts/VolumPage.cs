using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumPage : MonoBehaviour
{

    public Image BGM_Volum, EFFECT_Volum;
    public Sprite[] volumStatus;
    int bgmVol = 3, effectVol = 3;

    // Start is called before the first frame update
    void Start()
    {
        // 나중에 볼륨 상태 저장되고, 그 값을 불러오도록 설정하기
        bgmVol = 3;
        effectVol = 3;
        // 플레이어가 설정한 볼륨 크기 상태로 이미지 세팅
        BGM_Volum.sprite = volumStatus[bgmVol - 1];
        EFFECT_Volum.sprite = volumStatus[effectVol - 1];
    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR

        // left 버튼 (bgm 볼륨 다운)
        if (Input.GetKeyDown(KeyCode.LeftArrow) && bgmVol > 1)
        {
            bgmVol--;
            BGM_Volum.sprite = volumStatus[bgmVol - 1];
            print("bgmVol : " + bgmVol);
        }
        // right 버튼 (bgm 볼륨 업)
        else if (Input.GetKeyDown(KeyCode.RightArrow) && bgmVol < 5)
        {
            bgmVol++;
            BGM_Volum.sprite = volumStatus[bgmVol - 1];
            print("bgmVol : " + bgmVol);
        }
        // down 버튼 (effect 볼륨 다운)
        else if (Input.GetKeyDown(KeyCode.DownArrow) && effectVol > 1)
        {
            effectVol--;
            EFFECT_Volum.sprite = volumStatus[effectVol - 1];
            print("effectVol : " + effectVol);
        }
        // up 버튼 (effect 볼륨 업)
        else if (Input.GetKeyDown(KeyCode.UpArrow) && effectVol < 5)
        {
            effectVol++;
            EFFECT_Volum.sprite = volumStatus[effectVol - 1];
            print("effectVol : " + effectVol);
        }

#else
        // X 버튼 (bgm 볼륨 다운)
        if (Input.GetKeyDown(KeyCode.JoystickButton2) && bgmVol > 1)
        {
            bgmVol--;
            BGM_Volum.sprite = volumStatus[bgmVol - 1];
        }
        // B 버튼 (bgm 볼륨 업)
        else if (Input.GetKeyDown(KeyCode.JoystickButton1) && bgmVol < 5)
        {
            bgmVol++;
            BGM_Volum.sprite = volumStatus[bgmVol - 1];
        }
        // A 버튼 (effect 볼륨 다운)
        else if (Input.GetKeyDown(KeyCode.JoystickButton0) && effectVol > 1)
        {
            effectVol--;
            EFFECT_Volum.sprite = volumStatus[effectVol - 1];
        }
        // Y 버튼 (effect 볼륨 업)
        else if (Input.GetKeyDown(KeyCode.JoystickButton3) && effectVol < 5)
        {
            effectVol++;
            EFFECT_Volum.sprite = volumStatus[effectVol - 1];
        }
#endif
    }

}
