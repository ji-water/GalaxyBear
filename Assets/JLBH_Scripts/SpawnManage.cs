using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnManage : MonoBehaviour
{

    private int MaxEnemy;
    public int CurrentEnemy;
    public GameObject Parent;
    public GameObject[] Spawners = new GameObject[3];
    public Transform EnemyPrefab;
    public Transform EnemyPrefab2;
    Vector3 originscale;

    bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        MaxEnemy = 100;
        CurrentEnemy = 1;
        for(int i=0; i< 40; i++)
        {
            StartSpawn();
        }

        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentEnemy < MaxEnemy && flag)
        {
            flag = false;
            StartCoroutine(Spawn());
        }
    }

    void StartSpawn()
    {
        Vector3 position = (12) * Random.onUnitSphere;
        int enemyType = Random.Range(0, 2);
        Transform obj;
        obj = GameObject.Instantiate(EnemyPrefab, position , Quaternion.identity);
        obj.transform.SetParent(Parent.transform, true);
        CurrentEnemy++;
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            if (CurrentEnemy < MaxEnemy)
            {
                int ran = Random.Range(0, 5);
                int enemyType = Random.Range(0, 2);
                Debug.Log("Spawn from " + (ran + 1));
                Transform obj;
                if (enemyType == 0)
                    obj = GameObject.Instantiate(EnemyPrefab, Spawners[ran].transform.position, Quaternion.identity);
                else
                    obj = GameObject.Instantiate(EnemyPrefab2, Spawners[ran].transform.position, Quaternion.identity);
                //obj.parent = Parent.transform;
                obj.transform.SetParent(Parent.transform, true);
                CurrentEnemy++;
                yield return new WaitForSeconds(1.5f);
            }
            else
            {
                flag = true;
                break;
            }
                
        }
    }
}
