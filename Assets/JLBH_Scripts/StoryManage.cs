using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryManage : MonoBehaviour
{
    int storyCnt = 0;
    int storyNum = 4;
    public Text clickText;
    public GameObject[] story = new GameObject[4];
    bool flag = false;

    private IEnumerator coroutine;

    //Audio
    GameObject AudioManager;

    void Start()
    {
        AudioManager = GameObject.Find("AudioManager");
        gameObject.GetComponent<AudioSource>().clip = AudioManager.GetComponent<AudioManage>().st_effect1;
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetInt("EFFvol", 5) * 0.2f;
        gameObject.GetComponent<AudioSource>().Play();

        for (int i=1; i<storyNum; i++)
        {
            story[i].SetActive(false);
        }
        coroutine = showStory();
        StartCoroutine(coroutine);
    }

    private void Update()
    {
        // click or X Button
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if (!flag)
            {
                flag = true;
                clickText.text = "> SKIP (Click +1)";
            }
            else
                moveMain();
        }
    }

    IEnumerator showStory()
    {
        while (true)
        {
            storyCnt++;
            if (storyCnt >= storyNum)
                break;
           
            yield return new WaitForSeconds(3.5f);

            story[storyCnt].SetActive(true);
            for(int i=0; i<storyNum; i++)
            {
                if (i != storyCnt)
                    story[i].SetActive(false);
            }
            switch (storyCnt)
            {
                case 1:
                    gameObject.GetComponent<AudioSource>().clip = AudioManager.GetComponent<AudioManage>().st_effect2;
                    break;
                case 2:
                    gameObject.GetComponent<AudioSource>().clip = AudioManager.GetComponent<AudioManage>().st_effect3;
                    break;
                case 3:
                    gameObject.GetComponent<AudioSource>().clip = AudioManager.GetComponent<AudioManage>().st_effect4;
                    break;

            }
            gameObject.GetComponent<AudioSource>().volume= PlayerPrefs.GetInt("EFFvol", 5) * 0.2f;
            gameObject.GetComponent<AudioSource>().Play();

        }
        yield return new WaitForSeconds(3.5f);
        moveMain();
    }

    public void moveMain()
    {
        SceneManager.LoadScene("TitleScene");
    }

}
