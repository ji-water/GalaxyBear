using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowtoManager : MonoBehaviour
{
    public GameObject howto;
    public GameObject canvas;
    private int count = 0;
    public GameObject[] how;
    public GameObject buttons;

    GameObject SoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        canvas.SetActive(false);
        SoundEffect = GameObject.Find("SoundEffect");
        Debug.Log(count);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            SoundEffect.GetComponent<AudioSource>().Play();
            count++;
            
            if (count % 8 == 1)
            {
                buttons.SetActive(false);
                how[0].SetActive(false);
                how[1].SetActive(true);
            }
            else if (count % 8 == 2)
            {

                how[1].SetActive(false);
                how[2].SetActive(true);

            }
            else if (count % 8 == 3)
            {

                how[2].SetActive(false);
                how[3].SetActive(true);

            }
            else if (count % 8 == 4)
            {
                how[3].SetActive(false);
                how[4].SetActive(true);
            }
            else if (count % 8 == 5)
            {
                how[4].SetActive(false);
                how[5].SetActive(true);

            }
            else if (count % 8 == 6)
            {
                how[5].SetActive(false);
                how[6].SetActive(true);
            }
            else if (count % 8 == 7)
            {
                how[6].SetActive(false);
                how[7].SetActive(true);
            }
            else if (count % 8 == 0)
            {
                canvas.SetActive(true);
                buttons.SetActive(true);
                how[7].SetActive(false);
                how[0].SetActive(true);
                howto.SetActive(false);
                
            }
          
        }
    }


}
