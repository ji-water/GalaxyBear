using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManage2 : MonoBehaviour
{

    public GameObject[] enemy;
    void Start()
    {
        enemy = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            enemy[i] = transform.GetChild(i).gameObject;
        }
        StartCoroutine(CheckForGenerateEnemy());
    }

    IEnumerator CheckForGenerateEnemy()
    {
        while (true)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (enemy[i].activeSelf == false)
                {
                    enemy[i].SetActive(true);
                }

            }
            yield return new WaitForSeconds(10f);
        }
    }
}
