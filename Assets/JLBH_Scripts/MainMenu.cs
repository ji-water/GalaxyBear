using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text[] score = new Text[5];

    public void rankingLoad()
    {
        for(int i=0; i<5; i++)
        {
            score[i].text= "TOP "+(i+1)+" : "+PlayerPrefs.GetInt("score" + i, 0);
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    public void QuitApp()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
