using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRock : MonoBehaviour
{
    public rockManager RMG;
    public int rockSpeed = 5;
    public Transform explosionTrans;
    Transform rockTrans;
    Vector3 endPoint;

    // Start is called before the first frame update
    void Awake()
    {
        rockTrans = GetComponent<Transform>();
    }

    void Update()
    {
        float step = rockSpeed * Time.deltaTime;
        rockTrans.position = Vector3.MoveTowards(rockTrans.position, explosionTrans.position, step);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RockEndPos"))
        {
            RMG.onExplo();
            gameObject.SetActive(false);
        }
    }

}
