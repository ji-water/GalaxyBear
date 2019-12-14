using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManage2 : MonoBehaviour
{

    public GameObject[] enemy;
    int enemyLeng;

    void Start()
    {
        enemyLeng = enemy.Length;
        StartCoroutine("CheckForGenerateEnemy");
    }

    IEnumerator CheckForGenerateEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < enemyLeng; i++)
            {
                if (enemy[i].activeSelf == false)
                {
                    enemy[i].SetActive(true);
                }

                if (enemyLeng == 15)
                {
                    yield return new WaitForSeconds(5f);
                }
                
            }
        }
    }
}
