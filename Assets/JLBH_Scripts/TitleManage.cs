using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManage : MonoBehaviour
{
    public Transform title;
    public GameObject text;
    public Transform Canvas;

    GameObject AudioManager;

    void Start()
    {
        AudioManager = GameObject.Find("AudioManager");
        AudioManager.GetComponent<AudioManage>().bgmPlay();
        
        //title.position = Canvas.position;

        //StartCoroutine("moveTitle");
        StartCoroutine("textBlink");
    }

    void Update()
    {
        //아무키나 누르면 씬 넘어감
        if (Input.anyKeyDown)
        {
            StopCoroutine("textBlink");
            text.SetActive(false);
            StartCoroutine("moveTitle");
        }

    }

    IEnumerator textBlink()
    {
        while (true)
        {
            if (text.activeSelf)
            {
                text.SetActive(false);
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                text.SetActive(true);
                yield return new WaitForSeconds(1f);
            }
        }
    }

    IEnumerator moveTitle()
    {
        Vector3 tempV = new Vector3(0, 0.01f, 0);
        while (true) { 
            if (title.position.y > 0.2f)
            {
                SceneManager.LoadScene("MainScene");
            }
            title.Translate(tempV);
            yield return new WaitForSeconds(0.03f);
            print(title.position.y);
        }

    }
}
