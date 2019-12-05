using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowtoManager : MonoBehaviour
{
    public GameObject howto;
    private int count = 0;
    public GameObject[] how;

    GameObject SoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        SoundEffect = GameObject.Find("SoundEffect");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            SoundEffect.GetComponent<AudioSource>().Play();
            count++;
            if (count % 5 == 1)
            {
                how[0].SetActive(false);
                how[1].SetActive(true);
                how[2].SetActive(false);
                how[3].SetActive(false);
                how[4].SetActive(false);
            }
            else if (count % 5 == 2)
            {
                how[0].SetActive(false);
                how[1].SetActive(false);
                how[2].SetActive(true);
                how[3].SetActive(false);
                how[4].SetActive(false);
            }
            else if (count % 5 == 3)
            {
                how[0].SetActive(false);
                how[1].SetActive(false);
                how[2].SetActive(false);
                how[3].SetActive(true);
                how[4].SetActive(false);
            }
            else if (count % 5 == 4)
            {
                how[0].SetActive(false);
                how[1].SetActive(false);
                how[2].SetActive(false);
                how[3].SetActive(false);
                how[4].SetActive(true);
            }
            else if (count % 5 == 0)
            {
                how[0].SetActive(false);
                how[1].SetActive(false);
                how[2].SetActive(false);
                how[3].SetActive(false);
                how[4].SetActive(false);
                howto.SetActive(false);
            }
        }
    }


}
