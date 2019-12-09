using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public GameObject buttons;
    public GameObject RankingCanvas;
    public GameObject SettingCanvas;
    public GameObject SceneManager;
    public GameObject HowtoCanvas;

    static int buttonGaze = 0; //1:ranking,2:start,3:exit,4:howto,5:setting,6:canvas

    void Update()
    {
        if (buttonGaze != 0)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetKey(KeyCode.JoystickButton0))
            {
                SceneManager.GetComponent<MainMenu>().playEffect();
                switch (buttonGaze)
                {
                    case 1: //ranking
                        RankingCanvas.SetActive(true);
                        SceneManager.GetComponent<MainMenu>().rankingLoad();
                        buttons.SetActive(false);
                        break;
                    case 2: //start
                        SceneManager.GetComponent<MainMenu>().ChangeScene("GameScene");
                        break;
                    case 3://exit
                        SceneManager.GetComponent<MainMenu>().QuitApp();
                        break;
                    case 4://howto
                        HowtoCanvas.SetActive(true);
                        buttons.SetActive(false);
                        break;
                    case 5: //setting
                        SettingCanvas.SetActive(true);
                        buttons.SetActive(false);
                        break;
                    case 6: //canvas
                        RankingCanvas.SetActive(false);
                        HowtoCanvas.SetActive(false);
                        SettingCanvas.SetActive(false);
                        buttons.SetActive(true);
                        break;

                }
            }
        }
    }


    //pointer enter
    public void buttonInput()
    {
        SceneManager.GetComponent<MainMenu>().playEffect();
        switch (gameObject.transform.name)
        {
            case "Ranking":
                buttonGaze = 1;
                break;
            case "Start":
                buttonGaze = 2;
                break;
            case "Exit":
                buttonGaze = 3;
                break;
            case "Howto":
                buttonGaze = 4;
                break;
            case "Setting":
                buttonGaze = 5;
                break;
            case "Button":
                buttonGaze = 6;
                break;
        }
    }

    //pointer out
    public void buttonOut()
    {
        buttonGaze = 0;
    }

}
