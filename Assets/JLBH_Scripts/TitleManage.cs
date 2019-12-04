using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManage : MonoBehaviour
{
    GameObject title;
    GameObject text;

    private IEnumerator blink;
    private IEnumerator moveT;

    private void Start()
    {
        title = GameObject.Find("galaxyBear");
        text = GameObject.Find("Text");

        title.transform.position = new Vector3(0, 0, 800);

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
            if (title.transform.position.y > 700)
            {
                SceneManager.LoadScene("MainScene");
                StopCoroutine(moveT);
            }
            title.transform.Translate(new Vector3(0, 15f, 0));
            yield return new WaitForSeconds(0.03f);
        }

    }
}
