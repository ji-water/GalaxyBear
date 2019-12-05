using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrap : MonoBehaviour
{

    public Transform[] trap;
    int trapSpeed = 20;
    float[] initY;
    int trapLeng;
    int[] order;
    float gab = 0.15f; 

    // Start is called before the first frame update
    void Start()
    {
        trapLeng = trap.Length;
        order = new int[trapLeng];
        initY = new float[trapLeng];
        for (int i = 0; i < trapLeng; i++)
        {
            initY[i] = trap[i].position.y;
            order[i] = i;
        }
        Shuffle();
        StartCoroutine("SetTrap");
    }

    public void Shuffle()
    {
        int temp;
        for (int i = 0; i < trapLeng; i++)
        {
            int rnd = Random.Range(0, trapLeng);
            temp = order[rnd];
            order[rnd] = order[i];
            order[i] = temp;
        }
    }

    IEnumerator SetTrap()
    {
        int tempNum;
        Vector3 tempV;

        while (true)
        {
            // 랜덤으로 하나씩 내려가기
            for (int i = 0; i < trapLeng; i++)
            {
                tempNum = order[i];
                for (int j = 0; j < trapSpeed; j++)
                {
                    Vector3 moveDir = trap[tempNum].up * gab;
                    tempV = trap[tempNum].position - moveDir / trapSpeed;
                    trap[tempNum].position = tempV;
                    yield return new WaitForSeconds(0.01f);
                }
                yield return new WaitForSeconds(0.1f);
            }

            // 랜덤으로 하나씩 올라왔다 내려가기
            for (int i = 0; i < trapLeng; i++)
            {
                tempNum = order[i];
                for (int j = 0; j < trapSpeed; j++)
                {
                    Vector3 moveDir = trap[tempNum].up * gab;
                    tempV = trap[tempNum].position + moveDir / trapSpeed;
                    trap[tempNum].position = tempV;
                    yield return new WaitForSeconds(0.005f + 0.0005f * j);
                }
                yield return new WaitForSeconds(0.05f);
                for (int j = 0; j < trapSpeed; j++)
                {
                    Vector3 moveDir = trap[tempNum].up * gab;
                    tempV = trap[tempNum].position - moveDir / trapSpeed;
                    trap[tempNum].position = tempV;
                    yield return new WaitForSeconds(0.015f - 0.0005f * j);
                }
            }

            // 동시에 모두 올라오기
            for (int j = 0; j < trapSpeed; j++)
            {
                for (int i = 0; i < trapLeng; i++)
                {
                    tempNum = order[i];
                    Vector3 moveDir = trap[tempNum].up * gab;
                    tempV = trap[tempNum].position + moveDir / trapSpeed;
                    trap[tempNum].position = tempV;
                }
                yield return new WaitForSeconds(0.01f);
            }

            Shuffle();
            yield return new WaitForSeconds(1f);

        }

    }

}
