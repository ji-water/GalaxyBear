using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockManager : MonoBehaviour
{
    public Transform startTrans;
    public Transform rockTrans;
    public GameObject rockObj;
    public GameObject explosion;
    Transform exploTrans;
    Vector3 startV;

    // Start is called before the first frame update
    void Start()
    {
        exploTrans = explosion.GetComponent<Transform>();
        StartCoroutine("setRock");
    }

    public Vector3 getStartV()
    {
        return startV;
    }

    public void onExplo()
    {
        StartCoroutine("setExplo");
    }

    IEnumerator setExplo()
    {
        explosion.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        explosion.SetActive(true);
    }

    IEnumerator setRock()
    {
        while (true)
        {
            // 운석 충돌 주기는 랜덤하게
            //int waitTime = Random.Range(6, 20);
            //yield return new WaitForSeconds(waitTime);
            yield return new WaitForSeconds(2);
            // 운석 세팅
            startV = startTrans.position;
            rockTrans.position = startV;
            rockObj.SetActive(true);
            yield return new WaitForSeconds(4);
        }
    }
}
