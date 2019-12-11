using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject[] bullet1;
    public GameObject[] bullet2;
    public Transform bulletPos;
    public static int count;
    public static int a = 0;
    public int b = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bullett());
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyUp(KeyCode.C))
        {
            a++;
        }
#else
        if (Input.GetKeyUp(KeyCode.JoystickButton0)) //A
        {
            a++;
        }
#endif
    }

    IEnumerator bullett()
    {
        yield return new WaitForSeconds(1.5f);
        while (true)
        {
            if (a % 2 == 0)
            {
                //Instantiate(bullet1, bulletPos.transform.position, bulletPos.transform.rotation);
                bullet1[b%5].SetActive(true);
                bullet1[b % 5].transform.position = bulletPos.transform.position;

                for (int i = 0; i < 5; i++)
                    bullet2[i].SetActive(false);
                b++;
            }

            else
            {
                //Instantiate(bullet2, bulletPos.transform.position, bulletPos.transform.rotation);
                bullet2[b % 5].SetActive(true);
                bullet2[b % 5].transform.position = bulletPos.transform.position;
                for (int i = 0; i < 5; i++)
                    bullet1[i].SetActive(false);
                b++;
            }

            
            yield return new WaitForSeconds(0.2f);
        }

    }





}
