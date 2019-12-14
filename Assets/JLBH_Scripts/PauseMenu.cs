using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Transform pauseCanvas, pausePos;
    public GameObject pauseMenu;
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
                pauseCanvas.position = pausePos.position;
                pauseCanvas.rotation = pausePos.rotation;
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
#else
        if (Input.GetKeyDown(KeyCode.Escape)) //ESC
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
                pauseCanvas.position = pausePos.position;
                pauseCanvas.rotation = pausePos.rotation;
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
