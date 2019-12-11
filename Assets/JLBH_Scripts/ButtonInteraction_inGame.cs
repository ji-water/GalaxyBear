using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction_inGame : MonoBehaviour
{
    public enum BTYPE {Main = 0, Resume = 1, Restart = 2, Yes = 3, No = 4, None = 5};
    BTYPE buttonGaze = BTYPE.None, isYesType = BTYPE.None;

    public PauseMenu PM;
    public GameObject isReallyMove;

    public void buttonInput(int inputType)
    {
        BTYPE tempType = (BTYPE) inputType;
        buttonGaze = tempType;
        if (tempType == BTYPE.Main || tempType == BTYPE.Restart)
        {
            isYesType = tempType;
        }
    }

    //pointer out
    public void buttonOut()
    {
        buttonGaze = BTYPE.None;
    }

    private void OnEnable()
    {
        isReallyMove.SetActive(false);
    }

    void Update()
    {
        if(buttonGaze != BTYPE.None)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetKey(KeyCode.JoystickButton0))
            {
                switch (buttonGaze)
                {
                    case BTYPE.Main:
                        isYesType = BTYPE.Main;
                        isReallyMove.SetActive(true);
                        break;
                    case BTYPE.Resume:
                        PM.resume();
                        break;
                    case BTYPE.Restart:
                        isYesType = BTYPE.Restart;
                        isReallyMove.SetActive(true);
                        break;
                    case BTYPE.Yes:
                        if (isYesType == BTYPE.Main)
                        {
                            PM.moveMain();
                        }
                        else if (isYesType == BTYPE.Restart)
                        {
                            PM.restart();
                        }
                        break;
                    case BTYPE.No:
                        isYesType = BTYPE.None;
                        isReallyMove.SetActive(false);
                        break;
                }
            }
        }
    }
}
