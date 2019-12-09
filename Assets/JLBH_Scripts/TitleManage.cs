using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManage : MonoBehaviour
{
    GameObject title;
    GameObject text;
    GameObject Canvas;

    private IEnumerator blink;
    private IEnumerator moveT;

    GameObject AudioManager;

    void Start()
    {
        AudioManager = GameObject.Find("AudioManager");
        AudioManager.GetComponent<AudioManage>().bgmPlay();
        title = GameObject.Find("galaxyBear");
        text = GameObject.Find("Text");
        Canvas = GameObject.Find("Canvas");

        Vector3 pos = Canvas.transform.position;
        title.transform.position = pos;

        moveT = moveTitle();
        blink = textBlink();
        StartCoroutine(blink);
    }

    void Update()
    {
        //아무키나 누르면 씬 넘어감
        if (Input.anyKeyDown)
        {
            StopCoroutine(blink);
            text.SetActive(false);
            StartCoroutine(moveT);
           
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
        while (true) { 
            if (title.transform.position.y > 1400)
            {
                SceneManager.LoadScene("MainScene");
                StopCoroutine(moveT);
            }
            title.transform.Translate(new Vector3(0, 20f, 0));
            yield return new WaitForSeconds(0.03f);
        }

    }
}
