using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction_inGame : MonoBehaviour
{
    static int buttonGaze = 0; //1:Main,2:Resume,3:Restart
    public GameObject SceneManager;

    public void buttonInput()
    {
        switch (gameObject.transform.name)
        {
            case "Main":
                buttonGaze = 1;
                break;
            case "Resume":
                buttonGaze = 2;
                break;
            case "Restart":
                buttonGaze = 3;
                break;
        }
    }

    //pointer out
    public void buttonOut()
    {
        buttonGaze = 0;
    }

    void Update()
    {
        if(buttonGaze != 0)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetKey(KeyCode.JoystickButton0))
            {
                PauseMenu p = SceneManager.GetComponent<PauseMenu>();
                switch (buttonGaze)
                {
                    case 1: //main
                        p.moveMain();
                        break;
                    case 2: //resume
                        p.resume();
                        break;
                    //restart
                    case 3:
                        p.restart();
                        break;

                }
            }
        }
    }
}
