using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu, menuButton;
    bool isPause = false;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        // 일시정지 구현
        if (Input.GetKeyDown(KeyCode.P)) //P
        {
            if (isPause)
            {
                Time.timeScale = 1;
                isPause = false;
                pauseMenu.SetActive(false);
            }
            else
            {
                isPause = true;
               
                pauseMenu.SetActive(true);
                menuButton.SetActive(true);
                Time.timeScale = 0;
            }
        }
#else
        if (Input.GetKey(KeyCode.Escape)) //ESC
        {
            if (isPause)
            {
                Time.timeScale = 1;
                isPause = false;
                pauseMenu.SetActive(false);
            }
            else
            {
                isPause = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
#endif
    }


    public void restart()
    {
        Time.timeScale = 1;
        isPause = false;
        SceneManager.LoadScene("GameScene");
    }

    public void resume()
    {
        Time.timeScale = 1;
        isPause = false;
        pauseMenu.SetActive(false);
    }

    public void moveMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }
}
